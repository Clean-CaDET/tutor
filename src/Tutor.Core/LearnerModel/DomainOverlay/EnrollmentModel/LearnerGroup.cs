using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.InstructorModel;

namespace Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel
{
    public class LearnerGroup : Entity
    {
        public string Name { get; private set; }
        public List<GroupMembership> Membership { get; private set; }
        public List<Instructor> Instructors { get; private set; }
        public int CourseId { get; private set; }
    }
}
