#nullable enable
using Tutor.Core.BuildingBlocks;
using Tutor.Core.LearnerModel;

namespace Tutor.Core.EnrollmentModel
{
    public class GroupMembership : Entity
    {
        public int LearnerGroupId { get; set; }
        public Learner? Learner { get; set; }
        public Instructor? Instructor { get; set; }
        public Role Role { get; private set; }
    }
    
    public enum Role
    {
        Learner,
        Instructor
    }
}