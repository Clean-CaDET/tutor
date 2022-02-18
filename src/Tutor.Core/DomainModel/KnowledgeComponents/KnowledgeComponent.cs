using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponent
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public List<KnowledgeComponent> KnowledgeComponents { get; private set; }
        public List<KnowledgeComponentMastery> KnowledgeComponentMasteries { get; private set; }
        public List<AssessmentEvent> AssessmentEvents { get; private set; }
    }
}