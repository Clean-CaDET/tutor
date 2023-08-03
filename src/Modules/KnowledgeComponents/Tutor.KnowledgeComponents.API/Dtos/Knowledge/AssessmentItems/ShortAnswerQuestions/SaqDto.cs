namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;

public class SaqDto : AssessmentItemDto
{
    public string Text { get; set; }
    public List<string> AcceptableAnswers { get; set; }
    public string Feedback { get; set; }
    public int Tolerance { get; set; }
}