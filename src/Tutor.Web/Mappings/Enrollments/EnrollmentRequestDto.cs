using System;

namespace Tutor.Web.Mappings.Enrollments;

public class EnrollmentRequestDto
{
    public int[] LearnerIds { get; set; }
    public DateTime Start { get; set; }
}