using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LanguageModelConversations.Core.UseCases;

namespace Tutor.LanguageModelConversations.Infrastructure.Database;

public class LanguageModelConversationsUnitOfWork : UnitOfWork<LanguageModelConversationsContext>, ILanguageModelConversationsUnitOfWork
{
    public LanguageModelConversationsUnitOfWork(LanguageModelConversationsContext dbContext) : base(dbContext) {}
}
