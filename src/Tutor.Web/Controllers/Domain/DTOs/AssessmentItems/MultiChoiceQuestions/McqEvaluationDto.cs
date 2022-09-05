namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiChoiceQuestions
{
    public class McqEvaluationDto
    {
        public string CorrectAnswer { get; set; }
        public string Feedback { get; set; }
        public double CorrectnessLevel { get; set; }
    }
}