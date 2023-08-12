namespace Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    bool Exists(string username);
    User? Get(int id);
    User? GetActiveByName(string username);
    User Register(string username, string password, UserRole role);
    List<User> BulkRegister(List<string> usernames, List<string> passwords, UserRole role);
    int GetInstructorId(int userId);
    int GetLearnerId(int userId);
    void Delete(User user);
}