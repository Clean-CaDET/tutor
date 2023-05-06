namespace Tutor.Core.Domain.Stakeholders;

public class User
{
    public int Id { get; private set; }
    public string Username { get; internal set; }
    public string Password { get; private set; }
    public string Salt { get; private set; }
    public UserRole Role { get; private set; }
    public bool IsActive { get; set; }

    private User() {}
    public User(string username, string password, string salt, UserRole role)
    {
        Username = username;
        Password = password;
        Salt = salt;
        Role = role;
        IsActive = true;
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
    // All learner roles should start with 'Learner'
    Learner,
    LearnerCommercial
}