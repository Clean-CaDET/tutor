using System.Collections.Generic;
using Tutor.Web.Controllers.Learners;

namespace Tutor.Web.Controllers.Domain.DTOs.Enrollment;

public class GroupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<LearnerDto> Learners { get; set; }
}