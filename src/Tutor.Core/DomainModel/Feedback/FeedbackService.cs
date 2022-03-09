using FluentResults;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback)
        {
            if (emotionsFeedback.Comment == null)
                return Result.Fail("Empty Emotions Feedback");
            
            _feedbackRepository.SaveEmotionsFeedback(emotionsFeedback);
            return Result.Ok(emotionsFeedback);
        }

        public Result<CrowdReFeedback> SaveCrowdReFeedback(CrowdReFeedback crowdReFeedback)
        {
            if (crowdReFeedback.SoftwareComment == null)
                return Result.Fail("Empty Software Feedback");

            if (crowdReFeedback.ContentComment == null)
                return Result.Fail("Empty Content Feedback");

            _feedbackRepository.SaveCrowdReFeedback(crowdReFeedback);
            return Result.Ok(crowdReFeedback);
        }
    }
}
