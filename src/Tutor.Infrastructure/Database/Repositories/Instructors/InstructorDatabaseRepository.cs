using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.InstructorModel;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;

namespace Tutor.Infrastructure.Database.Repositories.Instructors;

public class InstructorDatabaseRepository : IInstructorRepository
{
    private readonly TutorContext _dbContext;

    public InstructorDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Instructor GetByUserId(int userId)
    {
        return _dbContext.Instructors.FirstOrDefault(i => i.UserId.Equals(userId));
    }

    public List<Course> GetOwnedCourses(int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Where(m => m.Instructor.Id.Equals(instructorId))
            .Include(m => m.Course.KnowledgeUnits)
            .Select(m => m.Course).ToList();
    }

    public List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId)
    {
        return _dbContext.Instructors.Include(i => i.Groups)
            .FirstOrDefault(i => i.Id.Equals(instructorId))?.Groups
            .Where(g => g.CourseId.Equals(courseId)).ToList();
    }
}