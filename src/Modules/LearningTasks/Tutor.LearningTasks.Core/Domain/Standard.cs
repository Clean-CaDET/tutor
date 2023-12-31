using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain
{
    public class Standard : Entity
    {
        public string Description { get; private set; }
        public int MaxPoints { get; private set; }

        public Standard(string description, int maxPoints)
        {
            Description = description;
            MaxPoints = maxPoints;
        }
    }
}

