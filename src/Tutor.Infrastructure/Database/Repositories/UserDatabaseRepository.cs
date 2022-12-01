using System;
using System.Linq;
using Tutor.Infrastructure.Security.Authentication;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Database.Repositories;

public class UserDatabaseRepository : IUserRepository
{
    private readonly TutorContext _dbContext;

    public UserDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User GetActiveByName(string username)
    {
        return _dbContext.Users
            .FirstOrDefault(user => user.Username == username && user.IsActive);
    }

    public int GetInstructorId(int userId)
    {
        var instructor = _dbContext.Instructors.FirstOrDefault(i => i.UserId == userId);
        if(instructor == null) throw new ArgumentException("Not found.");
        return instructor.Id;
    }

    public int GetLearnerId(int userId)
    {
        var learner = _dbContext.Learners.FirstOrDefault(i => i.UserId == userId);
        if (learner == null) throw new ArgumentException("Not found.");
        return learner.Id;
    }
}