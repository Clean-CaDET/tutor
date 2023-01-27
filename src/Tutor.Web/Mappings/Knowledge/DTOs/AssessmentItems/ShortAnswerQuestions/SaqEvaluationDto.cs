using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ShortAnswerQuestions;

[JsonDiscriminator("saqEvaluation", Policy = DiscriminatorPolicy.Always)]
public class SaqEvaluationDto : EvaluationDto
{
    public List<string> AcceptableAnswers { get; set; }
    public string Feedback { get; set; }
}