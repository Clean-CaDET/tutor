using AutoMapper;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Web.Mappings.Enrollments
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