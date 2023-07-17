using AutoMapper;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.Core.Domain;

namespace Tutor.Stakeholders.Core.Mappers;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {
        CreateMap<StakeholderAccountDto, Learner>();
        CreateMap<Learner, StakeholderAccountDto>();

        CreateMap<StakeholderAccountDto, Instructor>();
        CreateMap<Instructor, StakeholderAccountDto>();
    }
}