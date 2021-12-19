using FluentResults;
using System;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IAssessmentEventRepository _assessmentEventRepository;

        public SubmissionService(IAssessmentEventRepository assessmentEventRepository)
        {
            _assessmentEventRepository = assessmentEventRepository;
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
            _assessmentEventRepository.SaveSubmission(submission);

            return Result.Ok(evaluation);
        }
    }
}