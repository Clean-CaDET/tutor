using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.Domain.Stakeholders;

public class CourseOwnership : Entity
{
    public Course Course { get; set; }
    public Instructor Instructor { get; set; }
}