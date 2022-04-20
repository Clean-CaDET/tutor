using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public class LearnerAssessmentService : ILearnerAssessmentService
    {
        private readonly IKcMasteryRepository _kcMasteryRepository;

        public LearnerAssessmentService(IKcMasteryRepository kcMasteryRepository)
        {
            _kcMasteryRepository = kcMasteryRepository;
        }

        public Result<Evaluation> EvaluateAndSaveSubmission(Submission submission)
        {
            var assessmentItem = _kcMasteryRepository.GetDerivedAssessmentItem(submission.AssessmentItemId);
            if (assessmentItem == null)
                return Result.Fail("No assessment item with ID: " + submission.AssessmentItemId);

            var kcm = _kcMasteryRepository.GetFullKcMastery(assessmentItem.KnowledgeComponentId, submission.LearnerId);
            if (kcm == null)  return Result.Fail("Learner not enrolled in KC: " + assessmentItem.KnowledgeComponentId);

            var result = kcm.SubmitAssessmentItemAnswer(submission);

            _kcMasteryRepository.UpdateKcMastery(kcm);

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
            var kcm = _kcMasteryRepository.GetKcMasteryForAssessmentItem(helpEvent.AssessmentItemId, helpEvent.LearnerId);
            if (kcm == null) return Result.Fail("Cannot seek help for assessment item with ID: " + helpEvent.AssessmentItemId);

            var result = kcm.SeekHelpForAssessmentItem(helpEvent);

            _kcMasteryRepository.UpdateKcMastery(kcm);

            return result;
        }

        //Should be moved to an instructor service or whatever will be used to interact with the chatbot
        public Result SaveInstructorMessage(string message, int kcId, int learnerId)
        {
            var kcm = _kcMasteryRepository.GetBasicKcMastery(kcId, learnerId);
            if (kcm == null) return Result.Fail("Learner not enrolled in KC: " + kcId);

            var result = kcm.RecordInstructorMessage(message);
            _kcMasteryRepository.UpdateKcMastery(kcm);
            return result;
        }
    }
}