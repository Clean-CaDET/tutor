namespace Tutor.Core.Domain.Stakeholders;

public class Instructor
{
    //Should be moved to a better place
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
}