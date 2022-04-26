using AutoMapper;
using Tutor.Core.LearnerModel;

namespace Tutor.Web.Controllers.Learners
{
    public class LearnerProfile : Profile
    {
        public LearnerProfile()
        {
            CreateMap<LearnerDto, Learner>();
            CreateMap<Learner, LearnerDto>();
        }
    }
}