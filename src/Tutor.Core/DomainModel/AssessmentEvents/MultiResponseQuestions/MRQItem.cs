namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MRQItem
    {
        public int Id { get; private set; }
        public int MRQId { get; private set; }
        public string Text { get; private set; }
        public bool IsCorrect { get; private set; }
        public string Feedback { get; private set; }

        public MRQItem(int id, int mRQId, string text, bool isCorrect, string feedback)
        {
            Id = id;
            MRQId = mRQId;
            Text = text;
            IsCorrect = isCorrect;
            Feedback = feedback;
        }
    }
}