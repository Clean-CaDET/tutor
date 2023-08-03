using System.Text.Json.Serialization;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

[JsonDerivedType(typeof(EvaluationDto), typeDiscriminator: "base")]
[JsonDerivedType(typeof(McqEvaluationDto), typeDiscriminator: "mcqSubmission")]
[JsonDerivedType(typeof(MrqEvaluationDto), typeDiscriminator: "mrqSubmission")]
[JsonDerivedType(typeof(SaqEvaluationDto), typeDiscriminator: "saqSubmission")]
public class EvaluationDto
{
    public double CorrectnessLevel { get; set; }
    public bool Correct { get; set; }
}