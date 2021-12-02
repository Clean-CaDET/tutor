namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MrqItem
    {
        public int Id { get; private set; }
        public int MrqId { get; private set; }
        public string Text { get; private set; }
        public bool IsCorrect { get; private set; }
        public string Feedback { get; private set; }
    }
}