using System;

namespace Tutor.Infrastructure.Security.Authentication.Users;

public class User
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Salt { get; private set; }
    public UserRole Role { get; private set; }

    public bool IsPasswordIncorrect(string password)
    {
        return !Password.Equals(PasswordUtilities.HashPassword(password, Convert.FromBase64String(Salt)));
    }

    public string GetPrimaryRoleName()
    {
        return Role.ToString().ToLower();
    }
}

public enum UserRole
{
    Administrator,
    Instructor,
    Learner
}