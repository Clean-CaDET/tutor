using System.Linq;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database.Repositories.Stakeholders;

public class InstructorDatabaseRepository : IInstructorRepository
{
    private readonly TutorContext _dbContext;

    public InstructorDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Instructor GetByUserId(int userId)
    {
        return _dbContext.Instructors.FirstOrDefault(i => i.UserId.Equals(userId));
    }
}