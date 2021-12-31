#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.InstructorModel.Instructors
{
    public class DefaultInstructor : IInstructor
    {
        private readonly IKCRepository _ikcRepository;
        private readonly IAssessmentEventRepository _assessmentEventRepository;

        public DefaultInstructor(IKCRepository ikcRepository, IAssessmentEventRepository assessmentEventRepository)
        {
            _ikcRepository = ikcRepository;
            _assessmentEventRepository = assessmentEventRepository;
        }

        public Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId)
        {
            if (_assessmentEventRepository.GetAssessmentEventsByKnowledgeComponent(knowledgeComponentId).Count == 0) return Result.Fail("There are no assessment events yet.");
            var suitableAssessmentEvent = GetAssessmentEventWithoutSubmission(knowledgeComponentId, learnerId);
            return Result.Ok(suitableAssessmentEvent != null
                ? _assessmentEventRepository.GetDerivedAssessmentEvent(suitableAssessmentEvent.Id)
                : _assessmentEventRepository.GetDerivedAssessmentEvent(FindSubmissionWithMinCorrectness(knowledgeComponentId, learnerId).AssessmentEventId));
        }

        public void UpdateKcMastery(Submission submission, int knowledgeComponentId)
        {
            var currentCorrectnessLevel = _assessmentEventRepository
                .FindSubmissionWithMaxCorrectness(submission.AssessmentEventId, submission.LearnerId)?.CorrectnessLevel ?? 0.0;
            if (currentCorrectnessLevel > submission.CorrectnessLevel) return;

            var kcMastery = _ikcRepository.GetKnowledgeComponentMastery(submission.LearnerId, knowledgeComponentId);

            var kcMasteryIncrement = 100.0 / _assessmentEventRepository.CountAssessmentEvents(knowledgeComponentId)
                * (submission.CorrectnessLevel - currentCorrectnessLevel) / 100.0;
            kcMastery.IncreaseMastery(kcMasteryIncrement);

            _ikcRepository.UpdateKCMastery(kcMastery);
        }

        private AssessmentEvent? GetAssessmentEventWithoutSubmission(int knowledgeComponentId, int learnerId)
        {
            var assessmentEvents = _assessmentEventRepository.GetAssessmentEventsWithLearnerSubmissions(knowledgeComponentId, learnerId);
            return assessmentEvents.FirstOrDefault(ae => ae.Submissions.Count == 0);
        }

        private Submission FindSubmissionWithMinCorrectness(int knowledgeComponentId, int learnerId)
        {
            var lastSubmissions = FindLastSubmissions(knowledgeComponentId, learnerId);
            if (lastSubmissions.Count != 1)
                lastSubmissions.Remove(lastSubmissions.OrderBy(sub => sub.TimeStamp).Last());

            var submissionsWithMaxCorrectness = new List<Submission>();
            lastSubmissions.ForEach(sub =>
            {
                submissionsWithMaxCorrectness.Add(_assessmentEventRepository.
                    FindSubmissionWithMaxCorrectness(sub.AssessmentEventId, sub.LearnerId));
            });

            var submissionWithMinCorrectness =
                submissionsWithMaxCorrectness.OrderBy(sub => sub.CorrectnessLevel).First();
            return submissionWithMinCorrectness;
        }

        private List<Submission> FindLastSubmissions(int knowledgeComponentId, int learnerId)
        {
            var assessmentEvents = _assessmentEventRepository.GetAssessmentEventsWithLearnerSubmissions(knowledgeComponentId, learnerId);
            var lastSubmissions = new List<Submission>();
            assessmentEvents.ForEach(ae =>
            {
                var lastSubmission = ae.Submissions.First();
                ae.Submissions.ForEach(sub =>
                {
                    var compareResult = DateTime.Compare(lastSubmission.TimeStamp, sub.TimeStamp);
                    if (compareResult < 0)
                    {
                        lastSubmission = sub;
                    }
                });
                lastSubmissions.Add(lastSubmission);
            });

            return lastSubmissions;
        }
    }
}