using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IAssessmentEventSelector
    {
        Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponent, int learnerId);
    }
}