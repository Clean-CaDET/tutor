using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks
{
    public class ArrangeTaskEvaluation : Evaluation
    {
        public List<ArrangeTaskContainerEvaluation> ContainerEvaluations { get; }

        public ArrangeTaskEvaluation(int assessmentItemId, double correctnessLevel,
            List<ArrangeTaskContainerEvaluation> containerEvaluations) : base(assessmentItemId, correctnessLevel)
        {
            ContainerEvaluations = containerEvaluations;
        }
    }
}
