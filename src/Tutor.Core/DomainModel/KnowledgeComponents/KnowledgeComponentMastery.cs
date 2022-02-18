using System.Linq;
using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponentMastery
    {
        public int Id { get; private set; }
        public double Mastery { get; private set; }
        public KnowledgeComponent KnowledgeComponent { get; private set; }
        public int LearnerId { get; private set; }

        private KnowledgeComponentMastery() {}

        public KnowledgeComponentMastery(KnowledgeComponent knowledgeComponent)
        {
            Mastery = 0.0;
            KnowledgeComponent = knowledgeComponent;
        }

        public void UpdateKcMastery(Submission submission)
        {
            var assessmentEvent = KnowledgeComponent.AssessmentEvents.FirstOrDefault(ae => ae.Id == submission.AssessmentEventId);
            if (assessmentEvent == null) return;
            
            var currentCorrectnessLevel = assessmentEvent.GetMaximumSubmissionCorrectness();
            if (currentCorrectnessLevel > submission.CorrectnessLevel) return;
            
            var kcMasteryIncrement = 100.0 / KnowledgeComponent.AssessmentEvents.Count
                * (submission.CorrectnessLevel - currentCorrectnessLevel) / 100.0;

            Mastery += kcMasteryIncrement;
        }

        public Result<AssessmentEvent> SelectSuitableAssessmentEvent(IAssessmentEventSelector assessmentEventSelector)
        {
            return assessmentEventSelector.SelectSuitableAssessmentEvent(KnowledgeComponent.Id, LearnerId);
        }
    }
}