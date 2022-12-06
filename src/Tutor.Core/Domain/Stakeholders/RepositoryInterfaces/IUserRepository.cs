namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IUserRepository
{
    public User GetActiveByName(string username);
    public User Register(string username, string password, UserRole role);
    public int GetInstructorId(int userId);
    public int GetLearnerId(int userId);
}