using AutoMapper;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Web.Mappings.Stakeholders;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {
        CreateMap<LearnerDto, Learner>();
        CreateMap<Learner, LearnerDto>();

        CreateMap<InstructorDto, Instructor>();
        CreateMap<Instructor, InstructorDto>();
    }
}