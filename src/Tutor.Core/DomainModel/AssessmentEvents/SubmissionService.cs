using FluentResults;
using System;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.InstructorModel.Instructors;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IAssessmentEventRepository _assessmentEventRepository;
        private readonly IAssessmentEventSelector _assessmentEventSelector;
        private readonly IKCRepository _kcRepository;
        private readonly KnowledgeComponent _knowledgeComponent;

        public SubmissionService(IAssessmentEventRepository assessmentEventRepository,
            IAssessmentEventSelector assessmentEventSelector, KnowledgeComponent knowledgeComponent, IKCRepository kcRepository)
        {
            _assessmentEventRepository = assessmentEventRepository;
            _assessmentEventSelector = assessmentEventSelector;
            _knowledgeComponent = knowledgeComponent;
            _kcRepository = kcRepository;
        }

        public Result<Evaluation> EvaluateAndSaveSubmission(Submission submission)
        {
            var assessmentEvent = _assessmentEventRepository.GetDerivedAssessmentEvent(submission.AssessmentEventId);
            if (assessmentEvent == null)
                return Result.Fail("No assessment event with ID: " + submission.AssessmentEventId);

            Evaluation evaluation;
            try
            {
                evaluation = assessmentEvent.EvaluateSubmission(submission);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(e.Message);
            }

            if (evaluation.Correct) submission.MarkCorrect();
            submission.CorrectnessLevel = evaluation.CorrectnessLevel;
            
            // _knowledgeComponent.UpdateKcMastery(submission, assessmentEvent.KnowledgeComponentId, _assessmentEventRepository, _kcRepository);
            _assessmentEventSelector.UpdateKcMastery(submission, assessmentEvent.KnowledgeComponentId);
            _assessmentEventRepository.SaveSubmission(submission);

            return Result.Ok(evaluation);
        }
    }
}