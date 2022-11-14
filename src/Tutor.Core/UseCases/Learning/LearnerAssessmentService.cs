using FluentResults;
using System;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
{
    public class LearnerAssessmentService : ILearnerAssessmentService
    {
        private readonly IKcMasteryRepository _kcMasteryRepository;

        public LearnerAssessmentService(IKcMasteryRepository kcMasteryRepository)
        {
            _kcMasteryRepository = kcMasteryRepository;
        }

        public Result<Evaluation> SubmitAssessmentItemAnswer(int learnerId, int assessmentItemId, Submission submission)
        {
            var assessmentItem = _kcMasteryRepository.GetDerivedAssessmentItem(assessmentItemId);
            if (assessmentItem == null) return Result.Fail("No assessment item with ID: " + assessmentItemId);
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(assessmentItem.KnowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + assessmentItem.KnowledgeComponentId);

            Evaluation evaluation;
            try
            {
                evaluation = assessmentItem.Evaluate(submission);
            }
            catch (ArgumentException ex)
            {
                return Result.Fail(ex.Message);
            }

            var result = kcMastery.RecordAssessmentItemAnswerSubmission(assessmentItemId, submission, evaluation);
            if (result.IsFailed) return result.ToResult<Evaluation>();

            _kcMasteryRepository.UpdateKcMastery(kcMastery);

            return Result.Ok(evaluation);
        }

        public Result<double> GetMaxCorrectness(int learnerId, int assessmentItemId)
        {
            var kcm = _kcMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
            var itemMastery = kcm.AssessmentItemMasteries.Find(am => am.AssessmentItemId == assessmentItemId);
            return Result.Ok(itemMastery?.Mastery ?? 0.0);
        }

        public Result RecordHintRequest(int learnerId, int assessmentItemId)
        {
            var kcm = _kcMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
            if (kcm == null) return Result.Fail("Cannot seek hints for assessment item with ID: " + assessmentItemId);

            var result = kcm.RecordAssessmentItemHintRequest(assessmentItemId);

            if (result.IsSuccess) _kcMasteryRepository.UpdateKcMastery(kcm);

            return result;
        }

        public Result RecordSolutionRequest(int learnerId, int assessmentItemId)
        {
            var kcm = _kcMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
            if (kcm == null) return Result.Fail("Cannot seek solution for assessment item with ID: " + assessmentItemId);

            var result = kcm.RecordAssessmentItemSolutionRequest(assessmentItemId);

            if (result.IsSuccess) _kcMasteryRepository.UpdateKcMastery(kcm);

            return result;
        }

        //Should be moved to an instructor service or whatever will be used to interact with the chatbot
        public Result RecordInstructorMessage(int learnerId, int kcId, string message)
        {
            var kcm = _kcMasteryRepository.GetBasicKcMastery(kcId, learnerId);
            if (kcm == null) return Result.Fail("Learner not enrolled in KC: " + kcId);

            var result = kcm.RecordInstructorMessage(message);

            if (result.IsSuccess) _kcMasteryRepository.UpdateKcMastery(kcm);

            return result;
        }
    }
}