using AutoMapper;
using Tutor.Core.LearnerModel.Feedback;
using Tutor.Web.Controllers.Learners.DTOs.Feedback;

namespace Tutor.Web.Controllers.Learners.Mappers
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
