using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class CourseOwnership : Entity
{
    public Course Course { get; private set; }
    public int InstructorId { get; private set; }

    private CourseOwnership() {}

    public CourseOwnership(Course course, int instructorId)
    {
        Course = course;
        InstructorId = instructorId;
    }
}