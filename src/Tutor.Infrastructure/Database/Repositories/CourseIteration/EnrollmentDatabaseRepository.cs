using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.CourseIteration
{
    public class EnrollmentDatabaseRepository : IEnrollmentRepository
    {
        private readonly TutorContext _dbContext;

        public EnrollmentDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CountAllEnrollmentsInUnit(int unitId)
        {
            return _dbContext.UnitEnrollments.Count(enrollment => enrollment.KnowledgeUnit.Id == unitId);
        }

        // Should be reworked when we add course iteration concept.
        public List<Course> GetEnrolledCourses(int learnerId)
        {
            return _dbContext.LearnerGroups
                .Where(lg => lg.Membership.Any(m => m.Learner.Id.Equals(learnerId)))
                .Select(lg => lg.Course).Distinct().ToList();
        }

        public List<KnowledgeUnit> GetEnrolledAndActiveUnits(int courseId, int learnerId)
        {
            return _dbContext.UnitEnrollments
                .Where(ue => ue.LearnerId.Equals(learnerId)
                             && ue.KnowledgeUnit.Course.Id.Equals(courseId)
                             && ue.Status.Equals(EnrollmentStatus.Active))
                .Include(ue => ue.KnowledgeUnit)
                .Select(ue => ue.KnowledgeUnit).ToList();
        }

        public bool LearnerHasActiveEnrollment(int unitId, int learnerId)
        {
            return _dbContext.UnitEnrollments.Any(u => u.Status == EnrollmentStatus.Active &&
                                                       u.KnowledgeUnit.Id == unitId && u.LearnerId == learnerId);
        }
    }
}
