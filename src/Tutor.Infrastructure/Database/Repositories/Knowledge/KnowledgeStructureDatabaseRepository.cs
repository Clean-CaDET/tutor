using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge
{
    public class KnowledgeStructureDatabaseRepository : IKnowledgeStructureRepository
    {
        private readonly TutorContext _dbContext;

        public KnowledgeStructureDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public KnowledgeUnit GetUnitWithKcs(int unitId)
        {
            return _dbContext.KnowledgeUnits
                .Where(u => u.Id == unitId)
                .Include(u => u.KnowledgeComponents)
                .FirstOrDefault();
        }

        public List<KnowledgeComponent> GetKnowledgeComponentsForUnit(int unitId)
        {
            return _dbContext.KnowledgeComponents.Where(kc => kc.KnowledgeUnitId == unitId).ToList();
        }
    }
}
