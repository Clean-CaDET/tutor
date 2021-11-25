using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTaskEvaluation : Evaluation
    {
        public List<ArrangeTaskContainerEvaluation> ContainerEvaluations { get; }
        public ArrangeTaskEvaluation(int assessmentEventId, double correctnessLevel,
            List<ArrangeTaskContainerEvaluation> containerEvaluations) : base(assessmentEventId, correctnessLevel)
        {
            ContainerEvaluations = containerEvaluations;
        }
    }

    public class ArrangeTaskContainerEvaluation
    {
        public ArrangeTaskContainer FullAnswer { get; }
        public bool SubmissionWasCorrect { get; }

        public ArrangeTaskContainerEvaluation(ArrangeTaskContainer fullAnswer, bool submissionWasCorrect)
        {
            FullAnswer = fullAnswer;
            SubmissionWasCorrect = submissionWasCorrect;
        }
    }
}
