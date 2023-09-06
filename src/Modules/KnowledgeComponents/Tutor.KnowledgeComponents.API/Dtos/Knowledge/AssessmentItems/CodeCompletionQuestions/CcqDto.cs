using System.Text.Json.Serialization;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.CodeCompletionQuestions;

[JsonDerivedType(typeof(CcqDto), typeDiscriminator: "codeCompletionQuestion")]
public class CcqDto : AssessmentItemDto
{
    public string Text { get; set; }
    public string Code { get; set; }
    public List<CcqItemDto> Items { get; set; }
    public string Feedback { get; set; }
}