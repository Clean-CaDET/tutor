using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.LLM;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Core.Domain;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.LearningTasks.Core.UseCases.Learning;

public class TaskConversationService : ITaskConversationService
{
    private readonly IMapper _mapper;
    private readonly ITaskConversationRepository _conversationRepository;
    private readonly ILearningTaskRepository _taskRepository;
    private readonly ILearningTasksUnitOfWork _unitOfWork;
    private readonly ILlmConnection _llmConnection;
    private readonly IInternalWalletService _walletService;

    public TaskConversationService(IMapper mapper,
        ITaskConversationRepository conversationRepository, ILearningTaskRepository taskRepository,
        ILearningTasksUnitOfWork unitOfWork, ILlmConnection llmConnection, IInternalWalletService walletService)
    {
        _mapper = mapper;
        _conversationRepository = conversationRepository;
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        _llmConnection = llmConnection;
        _walletService = walletService;
    }

    public Result<TaskConversationDto> GetMostRecentConversation(int learningTaskId, int learnerId)
    {
        var conversation = _conversationRepository.GetMostRecentByLearningTaskId(learningTaskId, learnerId);
        if (conversation == null) return Result.Fail(FailureCode.NotFound);
        
        return _mapper.Map<TaskConversationDto>(conversation);
    }

    public async Task<Result<LlmMessage>> StartNewConversation(int learningTaskId, int learnerId, string userMessage)
    {
        var result = _walletService.GetFunds(learnerId);
        if (result.IsFailed || result.Value <= 0) return Result.Fail(FailureCode.NoFunds);

        var task = _taskRepository.Get(learningTaskId);
        if (task == null)
            return Result.Fail(FailureCode.NotFound);

        var conversation = new TaskConversation(learningTaskId, learnerId);
        _conversationRepository.Add(conversation);

        return await ProcessConversation(conversation, userMessage, task);
    }

    public async Task<Result<LlmMessage>> ContinueConversation(int conversationId, int learnerId, string userMessage)
    {
        var result = _walletService.GetFunds(learnerId);
        if (result.IsFailed || result.Value <= 0) return Result.Fail(FailureCode.NoFunds);

        var conversation = _conversationRepository.GetById(conversationId);
        if (conversation == null || conversation.LearnerId != learnerId) return Result.Fail(FailureCode.NotFound);

        var task = _taskRepository.Get(conversation.LearningTaskId);
        if (task == null) return Result.Fail(FailureCode.NotFound);

        return await ProcessConversation(conversation, userMessage, task);
    }

    private async Task<Result<LlmMessage>> ProcessConversation(TaskConversation conversation, string userMessage, LearningTask task)
    {
        var userMsg = new LlmMessage(userMessage, AiRole.User, new DateTime());
        conversation.Messages.Add(userMsg);

        var messages = new List<LlmMessage> { BuildSystemPrompt(task) };
        messages.AddRange(conversation.Messages);
        
        var llmResult = await _llmConnection.CompleteAsync(messages);
        
        if (llmResult.IsFailed) return Result.Fail(llmResult.Errors);

        var assistantMessage = llmResult.Value.Message;
        conversation.Messages.Add(assistantMessage);

        var spendResult = _walletService.SpendFunds(conversation.LearnerId, llmResult.Value.CompletionTokens!.Value);
        if (spendResult.IsFailed) return Result.Fail(spendResult.Errors);

        _conversationRepository.Update(conversation);
        var saveResult = _unitOfWork.Save();
        
        if (saveResult.IsFailed) return Result.Fail(saveResult.Errors);

        return Result.Ok(assistantMessage);
    }

    private static LlmMessage BuildSystemPrompt(LearningTask task)
    {
        string message = "TODO";
        return new LlmMessage(message, AiRole.System, DateTime.MinValue);
    }
}