using AutoMapper;
using Tutor.Elaborations.API.Dtos.ConceptRecords;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.Mappers;

public class ConceptRecordProfile : Profile
{
    public ConceptRecordProfile()
    {
        CreateMap<ConceptRecordDto, ConceptRecord>().ReverseMap();
        CreateMap<KeyPropositionDto, KeyProposition>().ReverseMap()
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level.ToString()));
        CreateMap<BoundaryConditionDto, BoundaryCondition>().ReverseMap()
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level.ToString()));
        CreateMap<CommonMisconceptionDto, CommonMisconception>().ReverseMap();
    }
}
