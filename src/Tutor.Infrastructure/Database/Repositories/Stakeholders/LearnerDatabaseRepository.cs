using System.Linq;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database.Repositories.Stakeholders;

public class LearnerDatabaseRepository : ILearnerRepository
{
    private readonly TutorContext _dbContext;

    public LearnerDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Learner GetByUserId(int userId)
    {
        return _dbContext.Learners.FirstOrDefault(learner => learner.UserId.Equals(userId));
    }

    public Learner GetByIndex(string index)
    {
        return _dbContext.Learners.FirstOrDefault(learner => learner.Index.Equals(index));
    }
}