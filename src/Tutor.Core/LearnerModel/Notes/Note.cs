namespace Tutor.Core.LearnerModel.Notes
{
    public class Note
    {
        public int Id { get; set; }
        public int LearnerId { get; set; }
        public int UnitId { get; set; }
        public string Text { get; set; }
    }
}