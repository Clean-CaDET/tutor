using System.Linq;
using Tutor.Core.ProgressModel.Feedback;

namespace Tutor.Infrastructure.Database.Repositories.Progress
{
    public class FeedbackDatabaseRepository : IFeedbackRepository
    {
        private readonly TutorContext _dbContext;

        public FeedbackDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveOrUpdate(LearningObjectFeedback feedback)
        {
            _dbContext.LearningObjectFeedback.Attach(feedback);
            _dbContext.SaveChanges();
        }

        public LearningObjectFeedback Get(int learningObjectId, int learnerId)
        {
            return _dbContext.LearningObjectFeedback.FirstOrDefault(feedback =>
                feedback.LearningObjectId == learningObjectId && feedback.LearnerId == learnerId);
        }
    }
}