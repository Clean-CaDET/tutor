using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Infrastructure.Database.Repositories.LearningUtilities
{
    public class FeedbackDatabaseRepository : IFeedbackRepository
    {
        private readonly TutorContext _dbContext;

        public FeedbackDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback)
        {
            _dbContext.EmotionsFeedbacks.Attach(emotionsFeedback);
            _dbContext.SaveChanges();
        }

        public void SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback)
        {
            _dbContext.TutorImprovementFeedbacks.Attach(tutorImprovementFeedback);
            _dbContext.SaveChanges();
        }
    }
}
