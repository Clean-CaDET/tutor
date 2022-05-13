using FluentResults;
using System;
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

        public Result<Evaluation> EvaluateAndSaveSubmission(int learnerId, int assessmentItemId, Submission submission)
        {
            var assessmentItem = _kcMasteryRepository.GetDerivedAssessmentItem(assessmentItemId);
            if (assessmentItem == null) return Result.Fail("No assessment item with ID: " + assessmentItemId);

            var kcm = _kcMasteryRepository.GetFullKcMastery(assessmentItem.KnowledgeComponentId, learnerId);
            if (kcm == null) return Result.Fail("Learner not enrolled in KC: " + assessmentItem.KnowledgeComponentId);

            Evaluation evaluation;
            try
            {
                evaluation = assessmentItem.Evaluate(submission);
            }
            catch (ArgumentException ex)
            {
                return Result.Fail(ex.Message);
            }
            
            kcm.SubmitAssessmentItemAnswer(assessmentItemId, submission, evaluation);
            _kcMasteryRepository.UpdateKcMastery(kcm);

            return Result.Ok(evaluation);
        }

        public Result<double> GetMaxCorrectness(int learnerId, int assessmentItemId)
        {
            var kcm = _kcMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
            var itemMastery = kcm.AssessmentMasteries.Find(am => am.AssessmentItemId == assessmentItemId);
            return Result.Ok(itemMastery?.Mastery ?? 0.0);
        }

        public Result SeekChallengeHints(int learnerId, int assessmentItemId)
        {
            return SeekHelp(new SoughtHints
            {
                LearnerId = learnerId,
                AssessmentItemId = assessmentItemId
            });
        }

        public Result SeekChallengeSolution(int learnerId, int assessmentItemId)
        {
            return SeekHelp(new SoughtSolution
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
        public Result SaveInstructorMessage(int learnerId, int kcId, string message)
        {
            var kcm = _kcMasteryRepository.GetBasicKcMastery(kcId, learnerId);
            if (kcm == null) return Result.Fail("Learner not enrolled in KC: " + kcId);

            var result = kcm.RecordInstructorMessage(message);
            _kcMasteryRepository.UpdateKcMastery(kcm);
            return result;
        }
    }
}