using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions
{
    public class MrqEvaluation : Evaluation
    {
        public List<MrqItemEvaluation> ItemEvaluations { get; }
        public MrqEvaluation(double correctnessLevel, List<MrqItemEvaluation> evaluations) : base(correctnessLevel)
        {
            ItemEvaluations = evaluations;
        }
    }
}