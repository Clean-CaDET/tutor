using System.Text.Json.Serialization;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

[JsonDerivedType(typeof(SubmissionDto), typeDiscriminator: "base")]
[JsonDerivedType(typeof(McqSubmissionDto), typeDiscriminator: "mcqSubmission")]
[JsonDerivedType(typeof(MrqSubmissionDto), typeDiscriminator: "mrqSubmission")]
[JsonDerivedType(typeof(SaqSubmissionDto), typeDiscriminator: "saqSubmission")]
public class SubmissionDto
{
    public int ReattemptCount { get; set; }
}