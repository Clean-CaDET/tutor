using FluentResults;

namespace Tutor.Core.DomainModel.KnowledgeComponents.AssessmentEventHelp
{
    public interface IAssessmentEventHelpService
    {
        Result SeekHelp(int learnerId, int assessmentEventId, string helpType);
    }
}
