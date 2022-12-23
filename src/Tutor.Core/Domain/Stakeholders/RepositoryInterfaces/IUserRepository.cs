using System.Collections.Generic;

namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IUserRepository
{
    public User GetActiveByName(string username);
    public User Register(string username, string password, UserRole role);
    public List<User> BulkRegister(List<string> usernames, List<string> passwords, UserRole role);
    public int GetInstructorId(int userId);
    public int GetLearnerId(int userId);
}