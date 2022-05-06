using System.Collections.Generic;
using Tutor.Web.Controllers.Learners;

namespace Tutor.Web.Controllers.Analytics
{
    public class LearnerProgressDto
    {
        public LearnerDto Learner;
        public List<KcmProgressDto> KnowledgeComponentProgress;
    }
}
