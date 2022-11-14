namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks
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