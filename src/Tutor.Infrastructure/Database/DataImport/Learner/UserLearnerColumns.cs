namespace Tutor.Infrastructure.Database.DataImport.Learner;

public class UserLearnerColumns
{
    public int Id { get; internal set; }
    public string Index { get; internal set; }
    public string Name { get; internal set; }
    public string Surname { get; internal set; }
    public string Password { get; internal set; }
    public string Salt { get; internal set; }
}