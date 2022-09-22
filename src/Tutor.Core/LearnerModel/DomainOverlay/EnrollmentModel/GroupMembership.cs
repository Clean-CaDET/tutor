using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel
{
    public class GroupMembership : Entity
    {
        public int LearnerGroupId { get; set; }
        public Learner Learner { get; set; }
    }
}