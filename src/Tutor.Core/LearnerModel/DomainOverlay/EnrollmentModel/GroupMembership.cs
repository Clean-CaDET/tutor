#nullable enable
using Tutor.Core.BuildingBlocks;
using Tutor.Core.InstructorModel;

namespace Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel
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