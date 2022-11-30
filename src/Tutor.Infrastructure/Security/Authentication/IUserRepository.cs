using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Security.Authentication;

public interface IUserRepository
{
    public User GetActiveByName(string username);
}