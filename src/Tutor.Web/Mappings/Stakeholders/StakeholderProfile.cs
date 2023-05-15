using AutoMapper;
using System.Collections.Generic;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Web.Mappings.Stakeholders;

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