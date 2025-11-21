using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class CourseReport : Entity
{
    public int CourseId { get; private set; }
    public int LearnerId { get; private set; }

    public string? Report { get; private set; }
}