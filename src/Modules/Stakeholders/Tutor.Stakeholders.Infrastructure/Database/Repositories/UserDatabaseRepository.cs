using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.Stakeholders.Infrastructure.Database.Repositories;

public class UserDatabaseRepository : IUserRepository
{
    private readonly StakeholdersContext _dbContext;

    public UserDatabaseRepository(StakeholdersContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(string username)
    {
        return _dbContext.Users.Any(user => user.Username == username);
    }

    public User? GetActiveByName(string username)
    {
        return _dbContext.Users
            .FirstOrDefault(user => user.Username == username && user.IsActive);
    }

    public User Register(string username, string password, UserRole role)
    {
        var salt = PasswordUtilities.GenerateSalt();
        var hashedPassword = PasswordUtilities.HashPassword(password, salt);
        var user = new User(username, hashedPassword, Convert.ToBase64String(salt), role);
        _dbContext.Users.Add(user);
        return user;
    }

    public List<User> BulkRegister(List<string> usernames, List<string> passwords, UserRole role)
    {
        var users = new List<User>();
        for (var i = 0; i < usernames.Count; i++)
        {
            var salt = PasswordUtilities.GenerateSalt();
            var hashedPassword = PasswordUtilities.HashPassword(passwords[i], salt);
            users.Add(new User(usernames[i], hashedPassword, Convert.ToBase64String(salt), role));
        }
        _dbContext.Users.AddRange(users);
        return users;
    }

    public int GetInstructorId(int userId)
    {
        var instructor = _dbContext.Instructors.FirstOrDefault(i => i.UserId == userId);
        if (instructor == null) throw new KeyNotFoundException("Not found.");
        return instructor.Id;
    }

    public int GetLearnerId(int userId)
    {
        var learner = _dbContext.Learners.FirstOrDefault(i => i.UserId == userId);
        if (learner == null) throw new KeyNotFoundException("Not found.");
        return learner.Id;
    }

    public User? Get(int id)
    {
        return _dbContext.Users.Find(id);
    }

    public void Delete(User user)
    {
        _dbContext.Users.Remove(user);
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}