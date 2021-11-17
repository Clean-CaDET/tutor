using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.Units;

namespace Tutor.Core.InstructorModel.Instructors
{
    public interface IInstructor
    {
        Result<List<KnowledgeNode>> SelectSuitableKnowledgeNode(int knowledgeComponentId, int learnerId);
    }
}