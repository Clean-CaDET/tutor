using System.Linq;
using Tutor.Core.LearnerModel;

namespace Tutor.Infrastructure.Database.Repositories.Learners
{
    public class LearnerDatabaseRepository : ILearnerRepository
    {
        private readonly TutorContext _dbContext;

        public LearnerDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Learner GetByIndex(string index)
        {
            return _dbContext.Learners.FirstOrDefault(learner => learner.StudentIndex.Equals(index));
        }

        public Learner Save(Learner learner)
        {
            _dbContext.Learners.Attach(learner);
            _dbContext.SaveChanges();
            return learner;
        }
    }
}