using System.Runtime.CompilerServices;
using System.Text.Json;
using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Internal;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public;
using Tutor.Elaborations.API.Public.Learning;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Core.UseCases.Learning;

public class ConversationService : IConversationService
{
    private const int MaxAttemptsPerDay = 3;

    private readonly IConversationAttemptRepository _attemptRepo;
    private readonly IConceptElaborationTaskRepository _taskRepo;
    private readonly TurnOrchestrator _turnOrchestrator;
    private readonly ITokenSpendingService _tokenSpendingService;
    private readonly IAccessServices _accessServices;
    private readonly IElaborationsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ConversationService(IConversationAttemptRepository attemptRepo,
        IConceptElaborationTaskRepository taskRepo,
        TurnOrchestrator turnOrchestrator, ITokenSpendingService tokenSpendingService,
        IAccessServices accessServices, IElaborationsUnitOfWork unitOfWork, IMapper mapper)
    {
        _attemptRepo = attemptRepo;
        _taskRepo = taskRepo;
        _turnOrchestrator = turnOrchestrator;
        _tokenSpendingService = tokenSpendingService;
        _accessServices = accessServices;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<List<LearnerElaborationSummaryDto>> GetTasksForUnit(int unitId, int learnerId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepo.GetByUnit(unitId);
        var taskIds = tasks.Select(t => t.Id).ToList();
        var completedTaskIds = _attemptRepo.GetTaskIdsWithCompletedAttempts(taskIds, learnerId);

        return Result.Ok(tasks.Select(t => new LearnerElaborationSummaryDto
        {
            Id = t.Id,
            UnitId = t.UnitId,
            Order = t.Order,
            Title = t.Title,
            HasCompletedAttempt = completedTaskIds.Contains(t.Id)
        }).ToList());
    }

    public Result<ConceptElaborationTaskDto> GetTaskDetail(int taskId, int learnerId)
    {
        var task = _taskRepo.Get(taskId);
        if (task == null) return Result.Fail(FailureCode.NotFound);

        if (!_accessServices.IsEnrolledInUnit(task.UnitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        var attempts = _attemptRepo.GetByTaskAndLearner(taskId, learnerId);

        var dto = _mapper.Map<ConceptElaborationTaskDto>(task);
        dto.Attempts = attempts.Select(a => _mapper.Map<ConversationAttemptDto>(a)).ToList();
        return Result.Ok(dto);
    }

    public async IAsyncEnumerable<string> StartConversationAsync(int taskId, string content,
        int learnerId, [EnumeratorCancellation] CancellationToken ct)
    {
        var task = _taskRepo.Get(taskId);
        if (task == null) { yield return BuildErrorChunk("Task not found.", 404); yield break; }

        if (!_accessServices.IsEnrolledInUnit(task.UnitId, learnerId))
        {
            yield return BuildErrorChunk("Not enrolled in unit.", 403);
            yield break;
        }

        var balanceCheck = _tokenSpendingService.HasSufficientBalanceForUnit(
            learnerId, task.UnitId, content.Length);
        if (balanceCheck.IsFailed)
        {
            yield return BuildErrorChunk("Insufficient token balance. Contact your administrator.", 402);
            yield break;
        }

        var existing = _attemptRepo.GetActiveAttempt(taskId, learnerId);
        if (existing != null)
        {
            yield return BuildErrorChunk("An active conversation already exists.", 409, existing.Id);
            yield break;
        }

        var recentCount = _attemptRepo.CountRecentAttempts(
            taskId, learnerId, DateTime.UtcNow.AddHours(-24));
        if (recentCount >= MaxAttemptsPerDay)
        {
            yield return BuildErrorChunk("You've practiced this concept recently. Come back tomorrow for another attempt.", 429);
            yield break;
        }

        var attempt = new ConversationAttempt(taskId, learnerId);
        _attemptRepo.Create(attempt);

        await foreach (var token in RunTurnPipelineAsync(attempt, task, content, ct))
            yield return token;
    }

    public async IAsyncEnumerable<string> SubmitTurnAsync(int attemptId, string content,
        int learnerId, [EnumeratorCancellation] CancellationToken ct)
    {
        var attempt = _attemptRepo.Get(attemptId);
        if (attempt == null) { yield return BuildErrorChunk("Attempt not found.", 404); yield break; }
        if (attempt.LearnerId != learnerId) { yield return BuildErrorChunk("Access denied.", 403); yield break; }
        if (attempt.Status != AttemptStatus.InProgress) { yield return BuildErrorChunk("Conversation is no longer active.", 409); yield break; }

        var task = _taskRepo.Get(attempt.ConceptElaborationTaskId);
        if (task == null) { yield return BuildErrorChunk("Task not found.", 404); yield break; }

        if (!_accessServices.IsEnrolledInUnit(task.UnitId, learnerId))
        {
            yield return BuildErrorChunk("Not enrolled in unit.", 403);
            yield break;
        }

        var balanceCheck = _tokenSpendingService.HasSufficientBalanceForUnit(
            learnerId, task.UnitId, content.Length);
        if (balanceCheck.IsFailed)
        {
            yield return BuildErrorChunk("Insufficient token balance. Contact your administrator.", 402);
            yield break;
        }

        await foreach (var token in RunTurnPipelineAsync(attempt, task, content, ct))
            yield return token;
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

    private async IAsyncEnumerable<string> RunTurnPipelineAsync(
        ConversationAttempt attempt, ConceptElaborationTask task, string content,
        [EnumeratorCancellation] CancellationToken ct)
    {
        // Synchronous phase: evaluate
        var evalResult = await _turnOrchestrator.EvaluateAsync(
            content, attempt.Turns.ToList(), task, ct);
        if (evalResult.IsFailed) { yield return BuildErrorChunk("Evaluation failed. Please try again.", 500); yield break; }

        var evaluation = evalResult.Value.Evaluation;
        attempt.AddLearnerTurn(content, evalResult.Value.IsSubstantive, evaluation);

        var isCompleted = task.IsAttemptComplete(attempt);
        var coveredKpIds = attempt.GetCoveredPropositionIds();
        var articulatedRelationIds = attempt.GetArticulatedRelationIds();
        var state = new ConversationState
        {
            IsCompleted = isCompleted,
            IsSoftCapReached = attempt.IsSoftCapReached(),
            IsHardCapReached = attempt.IsHardCapReached(),
            UncoveredKeyPropositionIds = task.KeyPropositions
                .Where(kp => !coveredKpIds.Contains(kp.Id))
                .Select(kp => kp.Id).ToList(),
            UnarticulatedKeyRelationIds = task.KeyRelations
                .Where(kr => !articulatedRelationIds.Contains(kr.Id))
                .Select(kr => kr.Id).ToList()
        };

        // Partial save: protects against stream interruption
        _unitOfWork.Save();

        // Streaming phase: dialogue
        var fullResponse = new System.Text.StringBuilder();
        await foreach (var token in _turnOrchestrator.StreamDialogueAsync(
            evaluation, attempt.Turns.ToList(), task, state, ct))
        {
            fullResponse.Append(token);
            yield return token;
        }

        // Post-stream persistence
        attempt.AddSystemTurn(fullResponse.ToString());

        string? summary = null;
        if (isCompleted)
        {
            var summaryResult = await _turnOrchestrator.SummarizeAsync(attempt, task, ct);
            summary = summaryResult.IsSuccess ? summaryResult.Value : null;
            attempt.Complete(summary);
        }
        else if (state.IsHardCapReached)
        {
            var summaryResult = await _turnOrchestrator.SummarizeAsync(attempt, task, ct);
            summary = summaryResult.IsSuccess ? summaryResult.Value : null;
            attempt.Expire(summary);
        }

        _unitOfWork.Save();

        // Spend tokens — estimate from content lengths
        _tokenSpendingService.SpendTokensForUnit(new TokenSpendingRequestDto
        {
            LearnerId = attempt.LearnerId,
            UnitId = task.UnitId,
            PromptTokens = content.Length / 4,
            CompletionTokens = fullResponse.Length / 4,
            FeatureType = "Elaboration",
            EntityId = task.Id,
            PromptSummary = "Concept conversation turn"
        });

        // Final metadata chunk
        yield return JsonSerializer.Serialize(new SubmitTurnResponseDto
        {
            AttemptId = attempt.Id,
            Status = attempt.Status.ToString(),
            Summary = summary
        });
    }

    private static string BuildErrorChunk(string message, int code, int? attemptId = null)
    {
        if (attemptId.HasValue)
            return JsonSerializer.Serialize(new { error = message, code, attemptId = attemptId.Value });
        return JsonSerializer.Serialize(new { error = message, code });
    }
}
