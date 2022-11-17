using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Stakeholders;

public class CourseOwnership : Entity
{
    public Course Course { get; private set; }
    public Instructor Instructor { get; private set; }
}