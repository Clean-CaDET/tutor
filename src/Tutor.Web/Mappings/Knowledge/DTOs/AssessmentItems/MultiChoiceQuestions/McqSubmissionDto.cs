using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions;

[JsonDiscriminator("mcqSubmission", Policy = DiscriminatorPolicy.Always)]
public class McqSubmissionDto : SubmissionDto
{
    public string Answer { get; set; }
}