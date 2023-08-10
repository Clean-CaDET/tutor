namespace Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

public interface ISummarizationRepository
{
    Summarization? GetByContextIdAndGroup(int contextId, ContextGroup group);
    Summarization Create(Summarization summarization);
}
