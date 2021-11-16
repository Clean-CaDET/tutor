using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.Units
{
    public class KnowledgeNode
    {
        public int Id { get; private set; }
        public List<AssessmentEvent> AssessmentEvents { get; private set; }
        public List<InstructionalEvent> InstructionalEvents { get; private set; }
    }
}