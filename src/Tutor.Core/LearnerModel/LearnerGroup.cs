using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.LearnerModel
{
    public class LearnerGroup : Entity
    {
        public string Name { get; private set; }
        public List<GroupMembership> Membership { get; private set; }
    }
}
