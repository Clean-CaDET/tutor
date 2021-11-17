using AutoMapper;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Web.Controllers.Learners.DTOs;

namespace Tutor.Web.Controllers.Learners
{
    public class LearnerProfile : Profile
    {
        public LearnerProfile()
        {
            CreateMap<LearnerDTO, Learner>();
            CreateMap<Learner, LearnerDTO>();

            CreateMap<NodeProgress, NodeProgressDTO>()
                .ForMember(dest => dest.AssessmentEvents, opt => opt.MapFrom(src => src.Node.AssessmentEvents))
                .ForMember(dest => dest.InstructionalEvents, opt => opt.MapFrom(src => src.Node.InstructionalEvents));
        }
    }
}