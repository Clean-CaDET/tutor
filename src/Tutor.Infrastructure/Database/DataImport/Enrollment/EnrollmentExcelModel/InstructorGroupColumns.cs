using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.Enrollment.EnrollmentExcelModel;

internal class InstructorGroupColumns
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CourseCode { get; set; }
    public HashSet<string> InstructorUsernames { get; set; }
}