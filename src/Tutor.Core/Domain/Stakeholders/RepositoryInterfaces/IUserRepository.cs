using FluentResults;
using System.Collections.Generic;

namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IUserRepository
{
    User GetActiveByName(string username);
    User Register(string username, string password, UserRole role);
    List<User> BulkRegister(List<string> usernames, List<string> passwords, UserRole role);
    Result<int> GetInstructorId(int userId);
    Result<int> GetLearnerId(int userId);
    User Get(int id);
    Result Delete(int id);
}