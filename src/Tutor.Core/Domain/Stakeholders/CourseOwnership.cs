using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Stakeholders;

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