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

    public List<Course> GetCourses(int instructorId)
    {
        return _dbContext.InstructorsCourses
            .Where(m => m.Instructor.Id.Equals(instructorId))
            .Include(m => m.Course)
            .Select(m => m.Course).ToList();
    }

    public List<LearnerGroup> GetGroups(int instructorId, int courseId)
    {
        return _dbContext.Instructors.Include(i => i.Groups)
            .FirstOrDefault(i => i.Id.Equals(instructorId))
            ?.Groups.ToList();
    }
}