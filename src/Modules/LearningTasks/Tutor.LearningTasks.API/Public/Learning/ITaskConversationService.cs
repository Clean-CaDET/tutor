using FluentResults;
using Tutor.BuildingBlocks.Core.LLM;
using Tutor.LearningTasks.API.Dtos;

namespace Tutor.LearningTasks.API.Public.Learning;

public interface ITaskConversationService
{
    Result<TaskConversationDto> GetMostRecentConversation(int learningTaskId, int learnerId);
    Task<Result<LlmMessage>> StartNewConversation(int learningTaskId, int learnerId, string userMessage);
    Task<Result<LlmMessage>> ContinueConversation(int conversationId, int learnerId, string userMessage);
}