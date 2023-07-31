using System.Text.Json.Serialization;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;

[JsonDerivedType(typeof(SaqDto), typeDiscriminator: "shortAnswerQuestion")]
public class SaqDto : AssessmentItemDto
{
    public string Text { get; set; }
    public List<string> AcceptableAnswers { get; set; }
    public string Feedback { get; set; }
    public int Tolerance { get; set; }
}