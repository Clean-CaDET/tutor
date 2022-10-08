using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutor.Core.DomainModel;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.EnrollmentModel;

namespace Tutor.Infrastructure.Database.Repositories.Domain
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

        public List<KnowledgeUnit> GetActiveUnits(int courseId, int learnerId)
        {
            return _dbContext.UnitEnrollments
                .Where(ue => ue.LearnerId.Equals(learnerId)
                             && ue.KnowledgeUnit.Course.Id.Equals(courseId)
                             && ue.Status.Equals(EnrollmentStatus.Active))
                .Include(ue => ue.KnowledgeUnit)
                .Select(ue => ue.KnowledgeUnit).ToList();
        }
    }
}
