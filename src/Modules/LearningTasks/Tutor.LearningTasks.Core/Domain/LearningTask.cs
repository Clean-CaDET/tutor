using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain
{
    public class LearningTask : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsTemplate { get; private set; }
        public DomainModel? DomainModel { get; private set; }
        public List<int>? CaseStudyIds { get; private set; }
        public List<Step>? Steps { get; private set; }

        public LearningTask(string name, string description, bool isTemplate, DomainModel domainModel, List<int> caseStudyIds, List<Step>? steps)
        {
            Name = name;
            Description = description;
            IsTemplate = isTemplate;
            DomainModel = domainModel;
            CaseStudyIds = caseStudyIds;
            Steps = steps;
        }
    }
}

