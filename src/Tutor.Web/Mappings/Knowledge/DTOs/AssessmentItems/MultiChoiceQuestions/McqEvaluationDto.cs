using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions;

[JsonDiscriminator("mcqEvaluation", Policy = DiscriminatorPolicy.Always)]
public class McqEvaluationDto : EvaluationDto
{
    public string CorrectAnswer { get; set; }
    public string Feedback { get; set; }
}