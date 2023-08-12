using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.Repositories;

public class InstructionalItemDatabaseRepository : CrudDatabaseRepository<InstructionalItem, KnowledgeComponentsContext>, IInstructionalItemRepository
{
    public InstructionalItemDatabaseRepository(KnowledgeComponentsContext dbContext): base(dbContext) {}

    public List<InstructionalItem> GetByKc(int kcId)
    {
        return DbContext.InstructionalItems.Where(i => i.KnowledgeComponentId == kcId).ToList();
    }
}