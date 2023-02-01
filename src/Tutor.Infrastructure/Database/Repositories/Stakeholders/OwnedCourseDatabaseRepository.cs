using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Infrastructure.Database.Repositories.Stakeholders;

public class OwnedCourseDatabaseRepository : IOwnedCourseRepository
{
    private readonly TutorContext _dbContext;

    public OwnedCourseDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public CourseOwnership GetCourseOwnership(int courseId, int instructorId)
    {
        return _dbContext.CourseOwnerships
            .FirstOrDefault(o => o.Course.Id == courseId && o.InstructorId == instructorId);
    }

    public List<Course> GetOwnedCourses(int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Where(m => m.InstructorId.Equals(instructorId))
            .Select(m => m.Course).ToList();
    }

    public List<Instructor> GetOwners(int courseId)
    {
        return _dbContext.CourseOwnerships
            .Where(m => m.Course.Id.Equals(courseId))
            .Select(m => m.Instructor).ToList();
    }

    public bool IsCourseOwner(int courseId, int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Any(m => m.InstructorId.Equals(instructorId) && m.Course.Id.Equals(courseId));
    }

    public bool IsUnitOwner(int unitId, int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Any(m => m.InstructorId.Equals(instructorId)
                      && m.Course.KnowledgeUnits.Any(ku => ku.Id.Equals(unitId)));
    }

    public bool IsKcOwner(int kcId, int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Any(m => 
                m.InstructorId.Equals(instructorId) && m.Course.KnowledgeUnits.Any(ku => 
                    ku.KnowledgeComponents.Any(kc => kc.Id == kcId)));
    }

    public Course GetOwnedCourseWithUnitsAndKcs(int courseId, int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Where(m => m.InstructorId.Equals(instructorId) && m.Course.Id.Equals(courseId))
            .Include(m => m.Course.KnowledgeUnits)
            .ThenInclude(ku => ku.KnowledgeComponents)
            .Select(m => m.Course).FirstOrDefault();
    }

    public void CreateCourseOwnership(CourseOwnership ownership)
    {
        _dbContext.CourseOwnerships.Add(ownership);
    }

    public void DeleteCourseOwnership(CourseOwnership ownership)
    {
        _dbContext.CourseOwnerships.Remove(ownership);
    }
}