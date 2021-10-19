using System.Linq;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Infrastructure.Database.Repositories
{
    public class LearnerDatabaseRepository : ILearnerRepository
    {
        private readonly SmartTutorContext _dbContext;

        public LearnerDatabaseRepository(SmartTutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Learner GetById(int learnerId)
        {
            return _dbContext.Learners.FirstOrDefault(l => l.Id == learnerId);
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
