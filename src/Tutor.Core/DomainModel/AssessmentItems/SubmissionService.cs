using FluentResults;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IAssessmentItemRepository _assessmentItemRepository;
        private readonly IKcRepository _kcRepository;

        public SubmissionService(IAssessmentItemRepository assessmentItemRepository, IKcRepository kcRepository)
        {
            _assessmentItemRepository = assessmentItemRepository;
            _kcRepository = kcRepository;
        }

        public Result<Evaluation> EvaluateAndSaveSubmission(Submission submission)
        {
            var assessmentItem = _assessmentItemRepository.GetDerivedAssessmentItem(submission.AssessmentItemId);
            if (assessmentItem == null)
                return Result.Fail("No assessment event with ID: " + submission.AssessmentItemId);

            var knowledgeComponentMastery = _kcRepository
                .GetKnowledgeComponentMastery(submission.LearnerId, assessmentItem.KnowledgeComponentId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("The Learner isn't enrolled to knowledge component with ID: " + assessmentItem.KnowledgeComponentId);

            var result = knowledgeComponentMastery.SubmitAssessmentItemAnswer(submission);   

            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result;
        }

        public Result<double> GetMaxCorrectness(int aeId, int learnerId)
        {
            var submission = _assessmentItemRepository.FindSubmissionWithMaxCorrectness(aeId, learnerId);
            return Result.Ok(submission?.CorrectnessLevel ?? 0.0);
        }
    }
}