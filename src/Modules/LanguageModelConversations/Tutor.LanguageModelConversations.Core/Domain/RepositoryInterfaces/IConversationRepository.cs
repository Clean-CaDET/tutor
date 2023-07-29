namespace Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

public interface IConversationRepository
{
    Conversation? Get(int id);
    Conversation? GetByLearnerAndContext(int learnerId, int contextId);
    Conversation Create(Conversation conversation);
    Conversation UpdateIfExisting(Conversation conversation);
}
