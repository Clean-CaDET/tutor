using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MrqEvaluation : Evaluation
    {
        public List<MrqItemEvaluation> ItemEvaluations { get; }
        public MrqEvaluation(int assessmentEventId, double correctnessLevel, List<MrqItemEvaluation> evaluations) : base(assessmentEventId, correctnessLevel)
        {
            ItemEvaluations = evaluations;
        }
    }
}