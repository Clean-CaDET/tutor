using AutoMapper;
using Tutor.Core.DomainModel.Feedback;
using Tutor.Web.Controllers.Domain.DTOs.Feedback;

namespace Tutor.Web.Controllers.Domain.Mappers
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<EmotionsFeedbackDto, EmotionsFeedback>();
        }
    }
}
