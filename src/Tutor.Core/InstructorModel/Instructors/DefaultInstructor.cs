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
            var suitableAssessmentEvent = GetAssessmentEventWithoutSubmission(knowledgeComponentId, learnerId);
            return Result.Ok(suitableAssessmentEvent != null ?
                _assessmentEventRepository.GetAssessmentEvent(suitableAssessmentEvent.Id) :
                _assessmentEventRepository.GetAssessmentEvent(FindLastSubmissionWithMinCorrectness(knowledgeComponentId, learnerId).AssessmentEventId));
        }

        public void UpdateKcMastery(Submission submission, int knowledgeComponentId)
        {
            var currentCorrectnessLevel = _assessmentEventRepository
                .FindSubmissionWithMaxCorrectness(submission.AssessmentEventId)?.CorrectnessLevel ?? 0.0;
            if (!(submission.CorrectnessLevel > currentCorrectnessLevel)) return;
            
            var kcMastery = _ikcRepository.GetKnowledgeComponentMastery
                (submission.LearnerId, knowledgeComponentId);

            _ikcRepository.UpdateKCMastery(kcMastery.Id, kcMastery.Mastery + 100.0
                / _ikcRepository.GetAssessmentEventsByKnowledgeComponent(knowledgeComponentId).Count
                * (submission.CorrectnessLevel - currentCorrectnessLevel) / 100.0);
        }

        private AssessmentEvent GetAssessmentEventWithoutSubmission(int knowledgeComponentId, int learnerId)
        {
            var assessmentEvents =
                _ikcRepository.GetAssessmentEventsByKnowledgeComponentAndLearner(knowledgeComponentId, learnerId);
            return assessmentEvents.FirstOrDefault(ae => ae.Submissions.Count == 0);
        }

        private Submission FindLastSubmissionWithMinCorrectness(int knowledgeComponentId, int learnerId)
        {
            var lastSubmissions = FindLastSubmissions(_ikcRepository.GetAssessmentEventsByKnowledgeComponentAndLearner(knowledgeComponentId, learnerId));
            lastSubmissions.Remove(lastSubmissions.OrderBy(sub => sub.TimeStamp).Last()); //TODO List can be empty after remove.
            var lastSubmissionWithMinCorrectness = lastSubmissions.OrderBy(sub => sub.CorrectnessLevel).First();
            return lastSubmissionWithMinCorrectness;
        }

        private static List<Submission> FindLastSubmissions(List<AssessmentEvent> assessmentEvents)
        {
            var lastSubmissions = new List<Submission>();
            assessmentEvents.ForEach(ae =>
            {
                var currentLastSubmission = ae.Submissions.First();
                ae.Submissions.ForEach(sub =>
                {
                    var compareResult = DateTime.Compare(currentLastSubmission.TimeStamp, sub.TimeStamp);
                    if (compareResult < 0)
                    {
                        currentLastSubmission = sub;
                    }
                });
                lastSubmissions.Add(currentLastSubmission);
            });

            return lastSubmissions;
        }
    }
}