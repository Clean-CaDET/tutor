namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions
{
    public class McqEvaluationDto : EvaluationDto
    {
        public string CorrectAnswer { get; set; }
        public string Feedback { get; set; }
    }
}