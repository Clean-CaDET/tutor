using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activites;

public class Activity : AggregateRoot
{
    public string Name { get; private set; }
    public Guidance Guidance { get; private set; }
    public List<Example>? Examples { get; private set; }
    public List<Subactivity>? Subactivities { get; private set; }

    public Activity(string name, Guidance guidance, List<Example> examples, List<Subactivity>? subactivities)
    {
        Name = name;
        Guidance = guidance;
        Examples = examples;
        Subactivities = subactivities;
    }
}

