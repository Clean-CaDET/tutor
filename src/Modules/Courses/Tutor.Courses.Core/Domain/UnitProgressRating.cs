using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class UnitProgressRating : Entity
{
    public int LearnerId { get; private set; }
    public int KnowledgeUnitId { get; private set; }
    public DateTime Created { get; private set; } = DateTime.UtcNow;
    public int[] CompletedKcIds { get; private set; }
    public int[] CompletedTaskIds { get; private set; }
    public string Feedback { get; private set; }
    public bool IsLearnerInitiated { get; private set; }

    private UnitProgressRating() {}
    
    public UnitProgressRating(int[] completedKcIds, int[] completedTaskIds, DateTime created, bool isLearnerInitiated)
    {
        CompletedKcIds = completedKcIds;
        CompletedTaskIds = completedTaskIds;
        Created = created;
        IsLearnerInitiated = isLearnerInitiated;
    }
}