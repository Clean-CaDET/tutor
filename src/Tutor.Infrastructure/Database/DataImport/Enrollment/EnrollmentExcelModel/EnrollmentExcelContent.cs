using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.Enrollment.EnrollmentExcelModel;

internal class EnrollmentExcelContent
{
    public List<InstructorColumns> Instructors { get; internal set; }
    public List<CourseOwnershipColumns> CourseOwnership { get; internal set; }
    public List<InstructorGroupColumns> CourseGroups { get; internal set; }
    public List<LearnerGroupColumns> LearnerGroups { get; internal set; }
}