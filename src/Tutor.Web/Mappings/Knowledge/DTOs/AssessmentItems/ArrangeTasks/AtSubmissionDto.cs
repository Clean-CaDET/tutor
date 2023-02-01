using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks;

[JsonDiscriminator("atSubmission", Policy = DiscriminatorPolicy.Always)]
public class AtSubmissionDto : SubmissionDto
{
    public List<AtContainerSubmissionDto> Containers { get; set; }
}