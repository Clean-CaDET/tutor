using System.Collections.Generic;
using Tutor.Web.Mappings.Enrollments;

namespace Tutor.Web.Mappings.Analytics
{
    public class LearnerProgressDto
    {
        public LearnerDto Learner { get; set; }
        public List<KcmProgressDto> KnowledgeComponentProgress { get; set; }
    }
}
