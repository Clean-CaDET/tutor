using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class LearningTask : AggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool isTemplate { get; private set; }
    public DomainModel? DomainModel { get; private set; }
    public List<CaseStudy>? CaseStudies { get; private set; }
    public List<Step>? Steps { get; private set; }
}

