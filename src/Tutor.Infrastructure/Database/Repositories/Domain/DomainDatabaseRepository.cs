using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        public KnowledgeUnit GetUnit(int id)
        {
            return _dbContext.KnowledgeUnits
                .Include(u => u.KnowledgeComponents)
                .FirstOrDefault(u => u.Id == id);
        }

        public List<KnowledgeUnit> GetUnits()
        {
            return _dbContext.KnowledgeUnits.ToList();
        }
    }
}
