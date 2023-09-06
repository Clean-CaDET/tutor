using System.Text.Json.Serialization;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.CodeCompletionQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

[JsonDerivedType(typeof(AssessmentItemDto), typeDiscriminator: "base")]
[JsonDerivedType(typeof(McqDto), typeDiscriminator: "multiChoiceQuestion")]
[JsonDerivedType(typeof(MrqDto), typeDiscriminator: "multiResponseQuestion")]
[JsonDerivedType(typeof(SaqDto), typeDiscriminator: "shortAnswerQuestion")]
[JsonDerivedType(typeof(CcqDto), typeDiscriminator: "codeCompletionQuestion")]
public class AssessmentItemDto
{
    public int Id { get; set; }
    public int KnowledgeComponentId { get; set; }
    public int Order { get; set; }
    public List<string> Hints { get; set; }
}