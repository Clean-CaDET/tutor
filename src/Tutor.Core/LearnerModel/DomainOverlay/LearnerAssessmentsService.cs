using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public class LearnerAssessmentsService : ILearnerAssessmentsService
    {
        private readonly IKcRepository _kcRepository;

        public LearnerAssessmentsService(IKcRepository kcRepository)
        {
            _kcRepository = kcRepository;
        }

        public Result<Evaluation> EvaluateAndSaveSubmission(Submission submission)
        {
            var assessmentItem = _kcRepository.GetDerivedAssessmentItem(submission.AssessmentItemId);
            if (assessmentItem == null)
                return Result.Fail("No assessment item with ID: " + submission.AssessmentItemId);

            var knowledgeComponentMastery = _kcRepository
                .GetKnowledgeComponentMastery(submission.LearnerId, assessmentItem.KnowledgeComponentId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("The Learner isn't enrolled to knowledge component with ID: " + assessmentItem.KnowledgeComponentId);

            var result = knowledgeComponentMastery.SubmitAssessmentItemAnswer(submission);   

            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result;
        }

        public Result<double> GetMaxSubmissionCorrectness(int aiId, int learnerId)
        {
            var submission = _kcRepository.FindSubmissionWithMaxCorrectness(aiId, learnerId);
            return Result.Ok(submission?.CorrectnessLevel ?? 0.0);
        }

        public Result SeekChallengeHints(int learnerId, int assessmentItemId)
        {
            return SeekHelp(new SoughtHints()
            {
                LearnerId = learnerId,
                AssessmentItemId = assessmentItemId
            });
        }

        public Result SeekChallengeSolution(int learnerId, int assessmentItemId)
        {
            return SeekHelp(new SoughtSolution()
            {
                LearnerId = learnerId,
                AssessmentItemId = assessmentItemId
            });
        }

        private Result SeekHelp(SoughtHelp helpEvent)
        {
            var knowledgeComponentMastery = _kcRepository
                .GetKnowledgeComponentMasteryByAssessmentItem(helpEvent.LearnerId, helpEvent.AssessmentItemId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("Cannot seek help for assessment item with ID: " + helpEvent.AssessmentItemId);

            var result = knowledgeComponentMastery.SeekHelpForAssessmentItem(helpEvent);

            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result;
        }
    }
}