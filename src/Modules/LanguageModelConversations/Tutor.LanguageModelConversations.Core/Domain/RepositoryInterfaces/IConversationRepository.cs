namespace Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

public interface IConversationRepository
{
    Conversation? Get(int id);
    Conversation? GetByLearnerContextIdAndGroup(int learnerId, int contextId, ContextGroup group);
    Conversation Create(Conversation conversation);
    Conversation UpdateIfExisting(Conversation conversation);
}
