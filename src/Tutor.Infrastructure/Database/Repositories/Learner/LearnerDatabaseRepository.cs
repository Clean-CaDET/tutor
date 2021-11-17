using System.Linq;
using Tutor.Core.LearnerModel;

namespace Tutor.Infrastructure.Database.Repositories.Learner
{
    public class LearnerDatabaseRepository : ILearnerRepository
    {
        private readonly TutorContext _dbContext;

        public LearnerDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Core.LearnerModel.Learners.Learner GetById(int learnerId)
        {
            return _dbContext.Learners.FirstOrDefault(l => l.Id == learnerId);
        }
        public Core.LearnerModel.Learners.Learner GetByIndex(string index)
        {
            return _dbContext.Learners.FirstOrDefault(learner => learner.StudentIndex.Equals(index));
        }

        public Core.LearnerModel.Learners.Learner Save(Core.LearnerModel.Learners.Learner learner)
        {
            _dbContext.Learners.Attach(learner);
            _dbContext.SaveChanges();
            return learner;
        }
    }
}
