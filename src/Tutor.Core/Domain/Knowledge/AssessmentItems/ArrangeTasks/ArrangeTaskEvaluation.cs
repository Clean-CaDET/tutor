using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks
{
    public class ArrangeTaskEvaluation : Evaluation
    {
        public List<ArrangeTaskContainerEvaluation> ContainerEvaluations { get; }

        public ArrangeTaskEvaluation(double correctnessLevel,
            List<ArrangeTaskContainerEvaluation> containerEvaluations) : base(correctnessLevel)
        {
            ContainerEvaluations = containerEvaluations;
        }
    }
}
