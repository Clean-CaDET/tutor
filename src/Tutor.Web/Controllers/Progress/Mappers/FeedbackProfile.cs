using AutoMapper;
using Tutor.Core.ProgressModel.Feedback;
using Tutor.Web.Controllers.Progress.DTOs.Feedback;

namespace Tutor.Web.Controllers.Progress.Mappers
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<LearningObjectFeedbackDTO, LearningObjectFeedback>();
            CreateMap<LearningObjectFeedback, LearningObjectFeedbackDTO>();
        }
    }
}