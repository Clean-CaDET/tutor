using System;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.Questions;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class AssessmentEventDatabaseRepository : IAssessmentEventRepository
    {
        public Challenge GetChallenge(int submissionChallengeId)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(int submissionQuestionId)
        {
            throw new NotImplementedException();
        }

        public ArrangeTask GetArrangeTask(int submissionArrangeTaskId)
        {
            throw new NotImplementedException();
        }
    }
}
