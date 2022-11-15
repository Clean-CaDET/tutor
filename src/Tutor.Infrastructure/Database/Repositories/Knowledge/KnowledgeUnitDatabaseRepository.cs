using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge
{
    public class KnowledgeUnitDatabaseRepository : IKnowledgeUnitRepository
    {
        private readonly TutorContext _dbContext;

        public KnowledgeUnitDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public KnowledgeUnit Get(int id)
        {
            return _dbContext.KnowledgeUnits
                .Include(u => u.KnowledgeComponents)
                .FirstOrDefault(u => u.Id == id);
        }

        public List<KnowledgeUnit> GetAll()
        {
            return _dbContext.KnowledgeUnits.ToList();
        }

        public List<KnowledgeUnit> GetByCourse(int courseId)
        {
            return _dbContext.Courses.Include(c => c.KnowledgeUnits)
                .FirstOrDefault(c => c.Id.Equals(courseId))
                ?.KnowledgeUnits.ToList();
        }
    }
}
