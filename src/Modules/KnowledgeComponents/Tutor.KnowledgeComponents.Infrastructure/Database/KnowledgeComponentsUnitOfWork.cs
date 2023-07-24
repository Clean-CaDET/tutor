using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.KnowledgeComponents.Core.UseCases;

namespace Tutor.KnowledgeComponents.Infrastructure.Database;

public class KnowledgeComponentsUnitOfWork : UnitOfWork<KnowledgeComponentsContext>, IKnowledgeComponentsUnitOfWork
{
    public KnowledgeComponentsUnitOfWork(KnowledgeComponentsContext dbContext) : base(dbContext) {}
}