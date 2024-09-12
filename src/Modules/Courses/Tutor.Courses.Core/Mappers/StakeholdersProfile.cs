using AutoMapper;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.Courses.Core.Mappers;

public class StakeholdersProfile : Profile
{
    public StakeholdersProfile()
    {
        CreateMap<StakeholderAccountDto, InstructorDto>();
        CreateMap<StakeholderAccountDto, LearnerDto>();
    }
}