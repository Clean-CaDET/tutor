using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutor.Infrastructure.Security.Authentication;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Database.Repositories
{
    public class UserDatabaseRepository : IUserRepository
    {
        private readonly TutorContext _dbContext;

        public UserDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByName(string username)
        {
            return _dbContext.Users
                .FirstOrDefault(user => user.Username == username);
        }

        public User Save(User user)
        {
            _dbContext.Users.Attach(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
