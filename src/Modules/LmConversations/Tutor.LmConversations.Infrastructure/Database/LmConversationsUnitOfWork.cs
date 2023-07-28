using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LmConversations.Core.UseCases;

namespace Tutor.LmConversations.Infrastructure.Database;

public class LmConversationsUnitOfWork : UnitOfWork<LmConversationsContext>, ILmConversationsUnitOfWork 
{
    public LmConversationsUnitOfWork(LmConversationsContext dbContext) : base(dbContext) {}
}
