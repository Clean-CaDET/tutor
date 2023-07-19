
namespace Tutor.LearningUtils.API.Dtos
{
    public class NoteDto
    {
        public int Id { get; set; }
        public int LearnerId { get; set; }
        public int UnitId { get; set; }
        public string Text { get; set; }
    }
}
