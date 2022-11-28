using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions
{
    public class MrqSubmissionDto : SubmissionDto
    {
        public List<MrqItemDto> Answers { get; set; }
    }
}