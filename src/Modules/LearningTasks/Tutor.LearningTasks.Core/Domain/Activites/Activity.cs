using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activites;

public class Activity : AggregateRoot
{
    public string Name { get; private set; }
    public int MaxPoints { get; private set; }
    public Guidance Guidance { get; private set; }
    public List<Example>? Examples { get; private set; }
    public List<Subactivity>? Subactivities { get; private set; }
    public SubmissionFormat? SubmissionFormat { get; private set; }
    public List<Standard>? Standards { get; private set; }
}

