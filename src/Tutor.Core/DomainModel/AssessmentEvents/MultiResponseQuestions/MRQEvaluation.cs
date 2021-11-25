using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MRQEvaluation : Evaluation
    {
        public List<MRQItemEvaluation> ItemEvaluations { get; }
        public MRQEvaluation(int assessmentEventId, double correctnessLevel, List<MRQItemEvaluation> evaluations) : base(assessmentEventId, correctnessLevel)
        {
            ItemEvaluations = evaluations;
        }
    }

    public class MRQItemEvaluation
    {
        public MRQItem FullItem { get; }
        public bool SubmissionWasCorrect { get; }

        public MRQItemEvaluation(MRQItem item, bool isCorrect)
        {
            FullItem = item;
            SubmissionWasCorrect = isCorrect;
        }
    }
}