using System.Linq;
using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.InstructorModel.Instructors;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponentMastery
    {
        public int Id { get; private set; }
        public double Mastery { get; private set; }
        public KnowledgeComponent KnowledgeComponent { get; private set; }
        public int LearnerId { get; private set; }

        public KnowledgeComponentMastery()
        {
        }

        public KnowledgeComponentMastery(KnowledgeComponent knowledgeComponent)
        {
            Mastery = 0.0;
            KnowledgeComponent = knowledgeComponent;
        }

        public void UpdateKcMastery(Submission submission, IKCRepository kcRepository)
        {
            var submissions = KnowledgeComponent.AssessmentEvents
                .FirstOrDefault(ae => ae.Id == submission.AssessmentEventId)?.Submissions;
            var currentCorrectnessLevel = 0.0;

            if (submissions?.Any() == true)
            {
                currentCorrectnessLevel = submissions.OrderBy(sub => sub.CorrectnessLevel).Last().CorrectnessLevel;
            }

            if (currentCorrectnessLevel > submission.CorrectnessLevel) return;
            var kcMasteryIncrement = 100.0 / KnowledgeComponent.AssessmentEvents.Count
                * (submission.CorrectnessLevel - currentCorrectnessLevel) / 100.0;

            Mastery += kcMasteryIncrement;
            kcRepository.UpdateKCMastery(this);
        }

        public Result<AssessmentEvent> SelectSuitableAssessmentEvent(IAssessmentEventSelector assessmentEventSelector)
        {
            return assessmentEventSelector.SelectSuitableAssessmentEvent(KnowledgeComponent.Id, LearnerId);
        }
    }
}