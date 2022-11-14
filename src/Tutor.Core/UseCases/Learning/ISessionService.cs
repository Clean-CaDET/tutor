using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.UseCases.Learning
{
    public interface ISessionService
    {
        Result LaunchSession(int knowledgeComponentId, int learnerId);
        Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId);
        Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId);
        Result TerminateSession(int knowledgeComponentId, int learnerId);
    }
}