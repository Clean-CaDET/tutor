using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge
{
    public class KnowledgeComponentDatabaseRepository : IKnowledgeComponentRepository
    {
        private readonly TutorContext _dbContext;

        public KnowledgeComponentDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<KnowledgeComponent> GetKnowledgeComponentsForUnit(int unitId)
        {
            return _dbContext.KnowledgeComponents.Where(kc => kc.KnowledgeUnitId == unitId).ToList();
        }
    }
}
