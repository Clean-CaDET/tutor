using System.Collections.Generic;
using System.Linq;
using Tutor.Core.KnowledgeComponentModel;
using Tutor.Core.KnowledgeComponentModel.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.Repositories
{
    public class KCDatabaseRepository : IKCRepository
    {
        private readonly TutorContext _dbContext;

        public KCDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<KnowledgeComponent> GetKnowledgeComponent()
        {
            return _dbContext.KnowledgeComponents.ToList();
        }
    }
}