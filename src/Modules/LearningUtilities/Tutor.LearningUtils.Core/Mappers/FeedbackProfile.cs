using AutoMapper;
using Tutor.LearningUtils.API.Dtos.Feedback;
using Tutor.LearningUtils.Core.Domain;

namespace Tutor.LearningUtils.Core.Mappers;

public class FeedbackProfile : Profile
{
    public FeedbackProfile()
    {
        CreateMap<EmotionsFeedbackDto, EmotionsFeedback>();
        CreateMap<EmotionsFeedback, EmotionsFeedbackDto>();
        CreateMap<ImprovementFeedbackDto, ImprovementFeedback>();
        CreateMap<ImprovementFeedback, ImprovementFeedbackDto>();
    }
}