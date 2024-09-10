using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

internal class PatternDetectorSatisfaction : INegativePatternDetector
{
    public List<string> Detect(List<KnowledgeComponentEvent> eventsUpToSatisfied, KnowledgeComponent kc)
    {
        if (eventsUpToSatisfied[^1] is not KnowledgeComponentSatisfied satisfied) return new List<string>();
        if (satisfied.MinutesToSatisfaction < kc.ExpectedDurationInMinutes)
        {
            return new List<string>
            {
                $"Brzanje: Ukupno vremena provedeno na komponenti je {Math.Round(satisfied.MinutesToSatisfaction, 1)} minuta."
            };
        }

        return new List<string>();
    }
}