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
            var assessmentEvents =
                _ikcRepository.GetAssessmentEventsByKnowledgeComponentAndLearner(knowledgeComponentId, learnerId);
            
            var suitableAssessmentEvent = assessmentEvents.FirstOrDefault(ae => ae.Submissions.Count == 0);
            if (suitableAssessmentEvent != null) return Result.Ok(suitableAssessmentEvent);
            
            var lastSubmissions = FindLastSubmissions(assessmentEvents);
            var submissionWithMinCorrectness= FindSubmissionWithMinCorrectness(lastSubmissions);
            suitableAssessmentEvent = assessmentEvents.FirstOrDefault(ae => ae.Id == submissionWithMinCorrectness.AssessmentEventId);
            
            return Result.Ok(suitableAssessmentEvent);
        }

        public void UpdateKcMastery(Submission submission, int knowledgeComponentId)
        {
            var currentCorrectnessLevel = _assessmentEventRepository
                .FindSubmissionWithMaxCorrectness(submission.AssessmentEventId).CorrectnessLevel;

            if (!(submission.CorrectnessLevel > currentCorrectnessLevel)) return;
            var kcCount = _ikcRepository
                .GetAssessmentEventsByKnowledgeComponent(knowledgeComponentId).Count;

            var kcMastery = _ikcRepository.GetKnowledgeComponentMastery
                (submission.LearnerId, knowledgeComponentId);

            var mastery = kcMastery.Mastery +
                          ((100.0 / kcCount) * (submission.CorrectnessLevel - currentCorrectnessLevel)) / 100.0;
            _ikcRepository.UpdateKCMastery(kcMastery.Id, mastery);
        }

        private static List<Submission> FindLastSubmissions(List<AssessmentEvent> assessmentEvents)
        {
            var lastSubmissions = new List<Submission>();
            assessmentEvents.ForEach(ae =>
            {
                var lastSubmissionTemp = ae.Submissions.First();
                ae.Submissions.ForEach(sub =>
                {
                    var compareResult = DateTime.Compare(lastSubmissionTemp.TimeStamp, sub.TimeStamp);
                    if (compareResult < 0)
                    {
                        lastSubmissionTemp = sub;
                    }
                });
                lastSubmissions.Add(lastSubmissionTemp);
            });
            
            return lastSubmissions;
        }

        private static Submission FindSubmissionWithMinCorrectness(ICollection<Submission> submissions)
        {
            var lastSubmission = submissions.OrderBy(sub => sub.TimeStamp).Last();
            submissions.Remove(lastSubmission);
            var lastSubmissionWithMinCorrectness = submissions.OrderBy(sub => sub.CorrectnessLevel).First();
            return lastSubmissionWithMinCorrectness;
        }
    }
}