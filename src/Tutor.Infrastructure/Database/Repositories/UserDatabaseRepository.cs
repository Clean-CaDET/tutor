using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;
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

    public User Register(string username, string password, UserRole role)
    {
        var salt = PasswordUtilities.GenerateSalt();
        var hashedPassword = PasswordUtilities.HashPassword(password, salt);
        var user = new User(username, hashedPassword, Convert.ToBase64String(salt), role);
        _dbContext.Users.Attach(user);
        _dbContext.SaveChanges();
        return user;
    }

    public int GetInstructorId(int userId)
    {
        var instructor = _dbContext.Instructors.FirstOrDefault(i => i.UserId == userId);
        if(instructor == null) throw new KeyNotFoundException("Not found.");
        return instructor.Id;
    }

    public int GetLearnerId(int userId)
    {
        var learner = _dbContext.Learners.FirstOrDefault(i => i.UserId == userId);
        if (learner == null) throw new KeyNotFoundException("Not found.");
        return learner.Id;
    }
}