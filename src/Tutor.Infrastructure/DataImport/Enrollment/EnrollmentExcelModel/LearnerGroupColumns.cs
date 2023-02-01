using System.Collections.Generic;

namespace Tutor.Infrastructure.DataImport.Enrollment.EnrollmentExcelModel;

internal class LearnerGroupColumns
{
    public int Id { get; set; }
    public string Name { get; set; }
    public HashSet<string> LearnerIndexes { get; set; }
}