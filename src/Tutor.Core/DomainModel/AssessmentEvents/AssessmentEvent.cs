using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public abstract class AssessmentEvent
    {
        public int Id { get; private set; }
        public int KnowledgeComponentId { get; private set; }

        public List<Submission> Submissions { get; private set; }
        
        protected AssessmentEvent() {}

        protected AssessmentEvent(int id, int knowledgeComponentId)
        {
            Id = id;
            KnowledgeComponentId = knowledgeComponentId;
        }

        public abstract Evaluation EvaluateSubmission(Submission submission);

        public abstract void ValidateInteraction(AssessmentEventInteraction interaction);

        public double GetMaximumSubmissionCorrectness()
        {
            return Submissions.Any() ? Submissions.OrderBy(sub => sub.CorrectnessLevel).Last().CorrectnessLevel : 0.0;
        }
    }
}