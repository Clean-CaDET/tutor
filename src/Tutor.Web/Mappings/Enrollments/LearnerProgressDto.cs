using System.Collections.Generic;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Mappings.Enrollments;

public class LearnerProgressDto
{
    public StakeholderAccountDto Learner { get; set; }
    public List<KcmProgressDto> KnowledgeComponentProgress { get; set; }
}