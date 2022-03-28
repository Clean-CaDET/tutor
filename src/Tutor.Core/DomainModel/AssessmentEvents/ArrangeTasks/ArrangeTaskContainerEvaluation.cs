namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTaskContainerEvaluation
    {
        public ArrangeTaskContainer FullAnswer { get; }
        public int IncorrectElementsCount { get; }

        public ArrangeTaskContainerEvaluation(ArrangeTaskContainer fullAnswer, int incorrectElementsCount)
        {
            FullAnswer = fullAnswer;
            IncorrectElementsCount = incorrectElementsCount;
        }
    }
}