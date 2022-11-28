using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks;

public class AtSubmissionDto : SubmissionDto
{
    public List<AtContainerSubmissionDto> Containers { get; set; }
}