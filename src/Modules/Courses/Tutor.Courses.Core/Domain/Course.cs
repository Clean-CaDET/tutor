using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class Course : Entity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public bool IsArchived { get; set; }
    public List<KnowledgeUnit>? KnowledgeUnits { get; internal set; }

    internal Course Clone(Course newCourse)
    {
        return new Course
        {
            Code = newCourse.Code,
            Name = newCourse.Name,
            Description = Description,
            StartDate = newCourse.StartDate,
            IsArchived = false,
            KnowledgeUnits = KnowledgeUnits?.Select(u => u.Clone()).ToList()
        };
    }

    public bool IsActive()
    {
        return !IsArchived && StartDate < DateTime.UtcNow;
    }
}