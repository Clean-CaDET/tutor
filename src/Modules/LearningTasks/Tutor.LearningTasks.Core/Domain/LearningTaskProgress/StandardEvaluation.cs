using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

public class StandardEvaluation : ValueObject
{
    public int StandardId { get; private set; }
    public double Points { get; private set; }
    public string Comment { get; private set; }

    public StandardEvaluation(int standardId, double points, string comment) 
    { 
        StandardId = standardId;
        Points = points;
        Comment = comment;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StandardId;
        yield return Points;
        yield return Comment;
    }
}
