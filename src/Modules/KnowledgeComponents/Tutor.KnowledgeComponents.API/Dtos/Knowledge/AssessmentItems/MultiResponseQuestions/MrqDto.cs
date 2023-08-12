using System.Text.Json.Serialization;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;

[JsonDerivedType(typeof(MrqDto), typeDiscriminator: "multiResponseQuestion")]
public class MrqDto : AssessmentItemDto
{
    public string Text { get; set; }
    public List<MrqItemDto> Items { get; set; }
}