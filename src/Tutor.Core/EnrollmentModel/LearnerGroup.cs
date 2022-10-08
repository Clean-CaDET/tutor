using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.EnrollmentModel
{
    public class LearnerGroup : Entity
    {
        public string Name { get; private set; }
        public List<GroupMembership> Membership { get; private set; }
        public Course Course { get; private set; }
    }
}
