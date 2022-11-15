using System.Collections.Generic;

namespace Tutor.Web.Mappings.CourseIteration;

public class GroupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<LearnerDto> Learners { get; set; }
}