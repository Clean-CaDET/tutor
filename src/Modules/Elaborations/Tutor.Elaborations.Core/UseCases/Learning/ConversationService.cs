using System.Runtime.CompilerServices;
using System.Text.Json;
using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Internal;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public;
using Tutor.Elaborations.API.Public.Learning;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.Domain.ElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Core.UseCases.Learning;

public class ConversationService : IConversationService
{
    private const int MaxAttemptsPerDay = 3;

    private readonly IConversationAttemptRepository _attemptRepo;
    private readonly IElaborationTaskRepository _taskRepo;
    private readonly Domain.ConceptRecords.IConceptRecordRepository _conceptRecordRepo;
    private readonly TurnOrchestrator _turnOrchestrator;
    private readonly ITokenSpendingService _tokenSpendingService;
    private readonly IAccessServices _accessServices;
    private readonly IElaborationsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ConversationService(IConversationAttemptRepository attemptRepo,
        IElaborationTaskRepository taskRepo,
        Domain.ConceptRecords.IConceptRecordRepository conceptRecordRepo,
        TurnOrchestrator turnOrchestrator, ITokenSpendingService tokenSpendingService,
        IAccessServices accessServices, IElaborationsUnitOfWork unitOfWork, IMapper mapper)
    {
        _attemptRepo = attemptRepo;
        _taskRepo = taskRepo;
        _conceptRecordRepo = conceptRecordRepo;
        _turnOrchestrator = turnOrchestrator;
        _tokenSpendingService = tokenSpendingService;
        _accessServices = accessServices;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<List<ElaborationTaskDto>> GetTasksForUnit(int unitId, int learnerId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepo.GetByUnit(unitId);
        return Result.Ok(tasks.Select(t => _mapper.Map<ElaborationTaskDto>(t)).ToList());
    }

    public async IAsyncEnumerable<string> SubmitTurnAsync(int taskId, string content,
        int learnerId, [EnumeratorCancellation] CancellationToken ct)
    {
        var task = _taskRepo.Get(taskId);
        if (task == null) { yield return BuildErrorChunk("Task not found.", 404); yield break; }

        if (!_accessServices.IsEnrolledInUnit(task.UnitId, learnerId))
            { yield return BuildErrorChunk("Not enrolled in unit.", 403); yield break; }

        var conceptRecord = _conceptRecordRepo.Get(task.ConceptRecordId);
        if (conceptRecord == null) { yield return BuildErrorChunk("Concept record not found.", 404); yield break; }

        var balanceCheck = _tokenSpendingService.HasSufficientBalanceForUnit(
            learnerId, task.UnitId, content.Length);
        if (balanceCheck.IsFailed)
            { yield return BuildErrorChunk("Insufficient token balance. Contact your administrator.", 402); yield break; }

        var attempt = _attemptRepo.GetActiveAttempt(taskId, learnerId);
        if (attempt == null)
        {
            var recentCount = _attemptRepo.CountRecentAttempts(
                taskId, learnerId, DateTime.UtcNow.AddHours(-24));
            if (recentCount >= MaxAttemptsPerDay)
                { yield return BuildErrorChunk("You've practiced this concept recently. Come back tomorrow for another attempt.", 429); yield break; }

            attempt = new ConversationAttempt(taskId, learnerId);
            _attemptRepo.Create(attempt);
        }

        var levelRecord = conceptRecord.DeriveForLevel(task.ExpectedLevel);

        // Synchronous phase: evaluate
        var evalResult = await _turnOrchestrator.EvaluateAsync(
            content, attempt.Turns.ToList(), levelRecord, ct);
        if (evalResult.IsFailed) { yield return BuildErrorChunk("Evaluation failed. Please try again.", 500); yield break; }

        var evaluation = evalResult.Value.Evaluation;
        attempt.AddLearnerTurn(content, evalResult.Value.IsSubstantive, evaluation);

        var isCompleted = levelRecord.AreAllPropositionsCovered(attempt);
        var state = new ConversationState
        {
            IsCompleted = isCompleted,
            IsSoftCapReached = attempt.IsSoftCapReached(),
            IsHardCapReached = attempt.IsHardCapReached()
        };

        // Partial save: protects against stream interruption
        _unitOfWork.Save();

        // Streaming phase: dialogue
        var fullResponse = new System.Text.StringBuilder();
        await foreach (var token in _turnOrchestrator.StreamDialogueAsync(
            evaluation, attempt.Turns.ToList(), levelRecord, state, ct))
        {
            fullResponse.Append(token);
            yield return token;
        }

        // Post-stream persistence
        attempt.AddSystemTurn(fullResponse.ToString());

        string? summary = null;
        if (isCompleted)
        {
            var summaryResult = await _turnOrchestrator.SummarizeAsync(attempt, levelRecord, ct);
            summary = summaryResult.IsSuccess ? summaryResult.Value : null;
            attempt.Complete(summary);
        }
        else if (state.IsHardCapReached)
        {
            var summaryResult = await _turnOrchestrator.SummarizeAsync(attempt, levelRecord, ct);
            summary = summaryResult.IsSuccess ? summaryResult.Value : null;
            attempt.Expire(summary);
        }

        _unitOfWork.Save();

        // Spend tokens — estimate from content lengths
        var totalChars = content.Length + fullResponse.Length;
        _tokenSpendingService.SpendTokensForUnit(new TokenSpendingRequestDto
        {
            LearnerId = learnerId,
            UnitId = task.UnitId,
            PromptTokens = content.Length / 4,
            CompletionTokens = fullResponse.Length / 4,
            FeatureType = "Elaboration",
            EntityId = taskId,
            PromptSummary = "Concept conversation turn"
        });

        // Final metadata chunk
        yield return JsonSerializer.Serialize(new SubmitTurnResponseDto
        {
            Status = attempt.Status.ToString(),
            Summary = summary
        });
    }

    public Result<ConversationAttemptDto> AbandonAttempt(int attemptId, int learnerId)
    {
        var attempt = _attemptRepo.Get(attemptId);
        if (attempt == null) return Result.Fail(FailureCode.NotFound);
        if (attempt.LearnerId != learnerId) return Result.Fail(FailureCode.Forbidden);
        if (attempt.Status != AttemptStatus.InProgress) return Result.Fail(FailureCode.Conflict);

        attempt.Abandon();
        _attemptRepo.Update(attempt);
        _unitOfWork.Save();

        return Result.Ok(_mapper.Map<ConversationAttemptDto>(attempt));
    }

    public Result<ConversationAttemptDto> GetAttempt(int attemptId, int learnerId)
    {
        var attempt = _attemptRepo.Get(attemptId);
        if (attempt == null) return Result.Fail(FailureCode.NotFound);
        if (attempt.LearnerId != learnerId) return Result.Fail(FailureCode.Forbidden);

        return Result.Ok(_mapper.Map<ConversationAttemptDto>(attempt));
    }

    public Result<List<ConversationAttemptDto>> GetAttempts(int taskId, int learnerId)
    {
        var attempts = _attemptRepo.GetByTaskAndLearner(taskId, learnerId);
        return Result.Ok(attempts.Select(a => _mapper.Map<ConversationAttemptDto>(a)).ToList());
    }

    private static string BuildErrorChunk(string message, int code)
    {
        return JsonSerializer.Serialize(new { error = message, code });
    }
}
