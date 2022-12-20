using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

public class KnowledgeComponentDatabaseRepository : CrudDatabaseRepository<KnowledgeComponent>, IKnowledgeComponentRepository
{
    public KnowledgeComponentDatabaseRepository(TutorContext dbContext) : base(dbContext) {}

    public List<KnowledgeComponent> GetKnowledgeComponentsForUnit(int unitId)
    {
        return DbContext.KnowledgeComponents.Where(kc => kc.KnowledgeUnitId == unitId).ToList();
    }

    public KnowledgeComponent GetKnowledgeComponentWithInstruction(int knowledgeComponentId)
    {
        return DbContext.KnowledgeComponents
            .Include(kc => kc.InstructionalItems)
            .FirstOrDefault(kc => kc.Id == knowledgeComponentId);
    }
}