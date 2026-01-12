namespace Tutor.KnowledgeComponents.API.Public.Learning;

public interface IKcChatbotService
{
    IAsyncEnumerable<string> AskQuestionAsync(int kcId, int learnerId, string userMessage, CancellationToken cancellationToken = default);
}
