using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.InstructorModel.Instructors;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponentMastery
    {
        public int Id { get; private set; }
        public double Mastery { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public int LearnerId { get; private set; }

        public KnowledgeComponentMastery(int knowledgeComponentId)
        {
            Mastery = 0.0;
            KnowledgeComponentId = knowledgeComponentId;
        }

        public void IncreaseMastery(double increment)
        {
            Mastery += increment;
        }

        // public void UpdateKcMastery(Submission submission, int knowledgeComponentId,
        //     IAssessmentEventRepository assessmentEventRepository,
        //     IKCRepository kcRepository)
        // {
        //     var currentCorrectnessLevel = assessmentEventRepository
        //         .FindSubmissionWithMaxCorrectness(submission.AssessmentEventId, submission.LearnerId)
        //         ?.CorrectnessLevel ?? 0.0;
        //     if (currentCorrectnessLevel > submission.CorrectnessLevel) return;
        //
        //     var kcMastery = kcRepository.GetKnowledgeComponentMastery(submission.LearnerId, knowledgeComponentId);
        //
        //     var kcMasteryIncrement = 100.0 / assessmentEventRepository.CountAssessmentEvents(knowledgeComponentId)
        //         * (submission.CorrectnessLevel - currentCorrectnessLevel) / 100.0;
        //     kcMastery.IncreaseMastery(kcMasteryIncrement);
        //
        //     kcRepository.UpdateKCMastery(kcMastery);
        // }
        //
        // public Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId,
        //     IAssessmentEventSelector assessmentEventSelector)
        // {
        //     return assessmentEventSelector.SelectSuitableAssessmentEvent(knowledgeComponentId, learnerId);
        // }
    }
}