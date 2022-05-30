using AutoMapper;
using Tutor.Core.LearnerModel.Feedback;

namespace Tutor.Web.Controllers.Learners.Feedback
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<EmotionsFeedbackDto, EmotionsFeedback>();
            CreateMap<TutorImprovementFeedbackDto, TutorImprovementFeedback>();
        }
    }
}
