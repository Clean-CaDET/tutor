using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public class LearnerAssessmentsService : ILearnerAssessmentsService
    {
        private readonly IKcMasteryRepository _kcMasteryRepository;

        public LearnerAssessmentsService(IKcMasteryRepository kcMasteryRepository)
        {
            _kcMasteryRepository = kcMasteryRepository;
        }

        public Result<Evaluation> EvaluateAndSaveSubmission(Submission submission)
        {
            var assessmentItem = _kcMasteryRepository.GetDerivedAssessmentItem(submission.AssessmentItemId);
            if (assessmentItem == null)
                return Result.Fail("No assessment item with ID: " + submission.AssessmentItemId);

            var knowledgeComponentMastery = _kcMasteryRepository
                .GetFullKcMastery(assessmentItem.KnowledgeComponentId, submission.LearnerId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("The Learner isn't enrolled to knowledge component with ID: " + assessmentItem.KnowledgeComponentId);

            var result = knowledgeComponentMastery.SubmitAssessmentItemAnswer(submission);   

            _kcMasteryRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result;
        }

        public Result<double> GetMaxSubmissionCorrectness(int aiId, int learnerId)
        {
            var submission = _kcMasteryRepository.FindSubmissionWithMaxCorrectness(aiId, learnerId);
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
            var knowledgeComponentMastery = _kcMasteryRepository
                .GetKcMasteryForAssessmentItem(helpEvent.AssessmentItemId, helpEvent.LearnerId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("Cannot seek help for assessment item with ID: " + helpEvent.AssessmentItemId);

            var result = knowledgeComponentMastery.SeekHelpForAssessmentItem(helpEvent);

            _kcMasteryRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result;
        }
    }
}