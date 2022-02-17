using System.Collections.Generic;
using System.Linq;
using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class AssessmentEventSelector : IAssessmentEventSelector
    {
        private readonly IAssessmentEventRepository _assessmentEventRepository;

        public AssessmentEventSelector(IAssessmentEventRepository assessmentEventRepository)
        {
            _assessmentEventRepository = assessmentEventRepository;
        }

        public Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId)
        {
            var assessmentEvents = _assessmentEventRepository.GetAssessmentEventsWithLearnerSubmissions(knowledgeComponentId, learnerId);
            if (assessmentEvents.Count == 0) return Result.Fail("No available assessment events.");

            var aeNoSubmission = FindAeWithNoSubmission(assessmentEvents);
            return Result.Ok(aeNoSubmission ?? FindAeWithMinCorrectSubmission(assessmentEvents));
        }

        private AssessmentEvent FindAeWithNoSubmission(List<AssessmentEvent> assessmentEvents)
        {
            var ae = assessmentEvents.FirstOrDefault(ae => ae.Submissions.Count == 0);
            return ae != null ? _assessmentEventRepository.GetDerivedAssessmentEvent(ae.Id) : null;
        }

        private AssessmentEvent FindAeWithMinCorrectSubmission(List<AssessmentEvent> assessmentEvents)
        {
            var lastSubmissions = FindLastSubmissionForEachAe(assessmentEvents);
            var maxCorrectnessSubmissions = FindMaxCorrectnessSubmissionForEachAe(assessmentEvents);

            if (lastSubmissions.Count != 1)
            {
                // Remove last made submission to avoid giving the learner the same AE.
                var lastSubmission = lastSubmissions.OrderBy(sub => sub.TimeStamp).Last();
                lastSubmissions.Remove(lastSubmission);
                maxCorrectnessSubmissions.Remove(lastSubmission);
            }

            var submissionWithMinCorrectness = maxCorrectnessSubmissions.OrderBy(sub => sub.CorrectnessLevel).First();
            return _assessmentEventRepository.GetDerivedAssessmentEvent(submissionWithMinCorrectness.AssessmentEventId);
        }

        private static List<Submission> FindLastSubmissionForEachAe(List<AssessmentEvent> assessmentEvents)
        {
            var lastSubmissions = new List<Submission>();

            foreach (var ae in assessmentEvents)
            {
                lastSubmissions.Add(ae.Submissions.OrderBy(sub => sub.TimeStamp).Last());
            }

            return lastSubmissions;
        }

        private static List<Submission> FindMaxCorrectnessSubmissionForEachAe(List<AssessmentEvent> assessmentEvents)
        {
            var maxCorrectnessSubmissions = new List<Submission>();

            foreach (var ae in assessmentEvents)
            {
                maxCorrectnessSubmissions.Add(ae.Submissions.OrderBy(sub => sub.CorrectnessLevel).Last());
            }

            return maxCorrectnessSubmissions;
        }
    }
}