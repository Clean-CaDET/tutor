using FluentResults;
using System;
using Tutor.Core.InstructorModel.Instructors;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IAssessmentEventRepository _assessmentEventRepository;
        private readonly IInstructor _instructor;

        public SubmissionService(IAssessmentEventRepository assessmentEventRepository,
            IInstructor instructor)
        {
            _assessmentEventRepository = assessmentEventRepository;
            _instructor = instructor;
        }

        public Result<Evaluation> EvaluateAndSaveSubmission(Submission submission)
        {
            var assessmentEvent = _assessmentEventRepository.GetAssessmentEvent(submission.AssessmentEventId);
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
            submission.SetCorrectnessLevel(evaluation.CorrectnessLevel);
            
            _instructor.UpdateKcMastery(submission, assessmentEvent.KnowledgeComponentId);
            _assessmentEventRepository.SaveSubmission(submission);

            return Result.Ok(evaluation);
        }
    }
}