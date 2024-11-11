using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

internal class PatternDetectorInstruction : INegativePatternDetector
{
    public List<string> Detect(List<KnowledgeComponentEvent> eventsUpToSatisfied, KnowledgeComponent kc)
    {
        var timeOnInstruction = 0.0;
        for (var i = 0; i < eventsUpToSatisfied.Count - 1; i++)
        {
            if (eventsUpToSatisfied[i] is not InstructionalItemsSelected e) continue;
            timeOnInstruction += (eventsUpToSatisfied[i + 1].TimeStamp - e.TimeStamp).TotalMinutes;
        }

        var retVal = new List<string>();
        if (timeOnInstruction < 1) retVal.Add(
            $"Preskakanje gradiva: Proveo {Math.Round(timeOnInstruction, 1)} minuta izučavajući gradivo pre nego što je završena komponenta.");

        return retVal;
    }
}