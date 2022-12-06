using System.Collections.Generic;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Mappings.CourseIteration;

public class GroupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<StakeholderAccountDto> Learners { get; set; }
}