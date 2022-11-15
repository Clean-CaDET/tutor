using System.Collections.Generic;

namespace Tutor.Web.Mappings.CourseIteration
{
    public class LearnerProgressDto
    {
        public LearnerDto Learner { get; set; }
        public List<KcmProgressDto> KnowledgeComponentProgress { get; set; }
    }
}
