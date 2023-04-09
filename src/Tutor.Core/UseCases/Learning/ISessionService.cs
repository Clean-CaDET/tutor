using FluentResults;

namespace Tutor.Core.UseCases.Learning;

public interface ISessionService
{
    Result LaunchSession(int knowledgeComponentId, int learnerId);
    Result TerminateSession(int knowledgeComponentId, int learnerId);
    Result PauseSession(int knowledgeComponentId, int learnerId);
    Result ContinueSession(int knowledgeComponentId, int learnerId);
    Result AbandonSession(int knowledgeComponentId, int learnerId);
}