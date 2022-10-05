using System.Collections.Generic;

namespace Tutor.Web.Mappings.Enrollments;

public class GroupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<LearnerDto> Learners { get; set; }
}