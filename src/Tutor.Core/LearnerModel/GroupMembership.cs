using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.LearnerModel
{
    public class GroupMembership : Entity
    {
        public Learner Learner { get; set; }
    }
}