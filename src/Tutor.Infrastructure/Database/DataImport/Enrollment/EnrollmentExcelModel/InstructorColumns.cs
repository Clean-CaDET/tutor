namespace Tutor.Infrastructure.Database.DataImport.Enrollment.EnrollmentExcelModel;

internal class InstructorColumns
{
    public int Id { get; internal set; }
    public string Username { get; internal set; }
    public string Name { get; internal set; }
    public string Surname { get; internal set; }
    public string Password { get; internal set; }
    public string Salt { get; internal set; }
}