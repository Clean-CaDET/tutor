namespace Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions
{
    public class MrqItemEvaluation
    {
        public MrqItem FullItem { get; }
        public bool SubmissionWasCorrect { get; }

        public MrqItemEvaluation(MrqItem item, bool isCorrect)
        {
            FullItem = item;
            SubmissionWasCorrect = isCorrect;
        }
    }
}