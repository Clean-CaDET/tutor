using System.Collections.Generic;

namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IUserRepository
{
    User GetByName(string username);
    List<User> GetByNames(List<string> usernames);
    User GetActiveByName(string username);
    User Register(string username, string password, UserRole role);
    List<User> BulkRegister(List<string> usernames, List<string> passwords, UserRole role);
    int GetInstructorId(int userId);
    int GetLearnerId(int userId);
    User Get(int id);
    void Delete(User user);
}