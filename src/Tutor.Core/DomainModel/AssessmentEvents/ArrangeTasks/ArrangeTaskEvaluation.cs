using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTaskEvaluation : Evaluation
    {
        public List<ArrangeTaskContainerEvaluation> ContainerEvaluations { get; }
        
        private double CorrectnessLevel { get; }
        
        public ArrangeTaskEvaluation(int assessmentEventId, double correctnessLevel,
            List<ArrangeTaskContainerEvaluation> containerEvaluations) : base(assessmentEventId, correctnessLevel)
        {
            ContainerEvaluations = containerEvaluations;
            CorrectnessLevel = correctnessLevel;
        }
    }
}
