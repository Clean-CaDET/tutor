using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IKCRepository _kcRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository, IKCRepository kCRepository)
        {
            _feedbackRepository = feedbackRepository;
            _kcRepository = kCRepository;
        }

        public Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback)
        {
            if (emotionsFeedback.Comment == null)
                return Result.Fail("Empty Emotions Feedback");
         
            var knowledgeComponent = _kcRepository.GetKnowledgeComponent(emotionsFeedback.KnowledgeComponentId);
            if (knowledgeComponent == null)
                return Result.Fail("No knowledge component with ID: " + emotionsFeedback.KnowledgeComponentId);
            
            _feedbackRepository.SaveEmotionsFeedback(emotionsFeedback);
            return Result.Ok(emotionsFeedback);
        }
    }
}
