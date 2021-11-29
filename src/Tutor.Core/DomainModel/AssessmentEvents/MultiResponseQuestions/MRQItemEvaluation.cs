namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MRQItemEvaluation
    {
        public MRQItem FullItem { get; }
        public bool SubmissionWasCorrect { get; }

        public MRQItemEvaluation(MRQItem item, bool isCorrect)
        {
            FullItem = item;
            SubmissionWasCorrect = isCorrect;
        }
    }
}