using Tutor.Core.BuildingBlocks;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.EnrollmentModel;

public class CourseOwnership : Entity
{
    public Course Course { get; set; }
    public Instructor Instructor { get; set; }
}