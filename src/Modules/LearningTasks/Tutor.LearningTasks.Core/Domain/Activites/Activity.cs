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

    public Activity(string name, int maxPoints, Guidance guidance, List<Example>? examples, List<Subactivity>? subactivities, SubmissionFormat? submissionFormat, List<Standard>? standards)
    {
        Name = name;
        MaxPoints = maxPoints;
        Guidance = guidance;
        Examples = examples;
        Subactivities = subactivities;
        SubmissionFormat = submissionFormat;
        Standards = standards;
    }
}

