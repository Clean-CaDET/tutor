using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

internal interface INegativePatternDetector
{
    List<string> Detect(List<KnowledgeComponentEvent> eventsUpToSatisfied, KnowledgeComponent kc);
}