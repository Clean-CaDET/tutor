using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;

[JsonDiscriminator("mrqSubmission", Policy = DiscriminatorPolicy.Always)]
public class MrqSubmissionDto : SubmissionDto
{
    public List<MrqItemDto> Answers { get; set; }
}