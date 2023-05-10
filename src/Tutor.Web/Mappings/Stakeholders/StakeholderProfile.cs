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

        CreateMap<(List<Learner> existingLearners, List<Learner> newLearners), BulkAccountsDto>()
            .ForMember(dest => dest.ExistingAccounts, opt => opt.MapFrom(src => src.existingLearners))
            .ForMember(dest => dest.NewAccounts, opt => opt.MapFrom(src => src.newLearners));
    }
}