namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MRQAnswer
    {
        public int Id { get; private set; }
        public int MRQContainerId { get; private set; }
        public string Text { get; private set; }
        public bool IsCorrect { get; private set; }
        public string Feedback { get; private set; }

        public MRQAnswer(int id, int mRQContainerId, string text, bool isCorrect, string feedback)
        {
            Id = id;
            MRQContainerId = mRQContainerId;
            Text = text;
            IsCorrect = isCorrect;
            Feedback = feedback;
        }
    }
}