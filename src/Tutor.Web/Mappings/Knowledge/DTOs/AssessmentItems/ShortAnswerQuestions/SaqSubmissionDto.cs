using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ShortAnswerQuestions;

[JsonDiscriminator("saqSubmission", Policy = DiscriminatorPolicy.Always)]
public class SaqSubmissionDto : SubmissionDto
{
    public string Answer { get; set; }
}