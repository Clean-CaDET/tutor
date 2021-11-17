using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.Units;

namespace Tutor.Core.InstructorModel.Instructors
{
    public class DefaultInstructor : IInstructor
    {
        public DefaultInstructor()
        {
            //TODO: Repos
        }

        public Result<List<KnowledgeNode>> SelectSuitableKnowledgeNode(int knowledgeComponentId, int learnerId)
        {
            //TODO: Examine which KNs the learner has (not) completed for the given KC
            //TODO: Select the most suitable non-completed KN (advanced instructors can consider difficulty and other factors).
            throw new System.NotImplementedException();
        }
    }
}