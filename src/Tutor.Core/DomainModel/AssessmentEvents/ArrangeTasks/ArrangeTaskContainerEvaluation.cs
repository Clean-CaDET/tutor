namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
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