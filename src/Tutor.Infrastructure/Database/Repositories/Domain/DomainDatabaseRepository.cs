using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class DomainDatabaseRepository : IDomainRepository
    {
        private readonly TutorContext _dbContext;

        public DomainDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<KnowledgeUnit> GetUnits()
        {
            return _dbContext.KnowledgeUnits.ToList();
        }
    }
}
