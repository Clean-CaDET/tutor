namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiResponseQuestions
{
    public class MrqItemEvaluationDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Feedback { get; set; }
        public bool SubmissionWasCorrect { get; set; }
    }
}