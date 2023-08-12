using System.Text.Json.Serialization;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;

[JsonDerivedType(typeof(McqDto), typeDiscriminator: "multiChoiceQuestion")]
public class McqDto : AssessmentItemDto
{
    public string Text { get; set; }
    public List<string> PossibleAnswers { get; set; }
    public string CorrectAnswer { get; set; }
    public string Feedback { get; set; }
}