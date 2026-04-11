using AutoMapper;
using Tutor.Elaborations.API.Dtos.ConceptRecords;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.Mappers;

public class ConceptRecordProfile : Profile
{
    public ConceptRecordProfile()
    {
        CreateMap<ConceptRecordDto, ConceptRecord>()
            .AfterMap((src, dest) =>
            {
                for (var i = 0; i < src.KeyRelations.Count; i++)
                {
                    var krDto = src.KeyRelations[i];
                    if (!krDto.SourceKeyPropositionIndex.HasValue
                        || !krDto.TargetKeyPropositionIndex.HasValue) continue;
                    var kr = dest.KeyRelations[i];
                    var source = dest.KeyPropositions[krDto.SourceKeyPropositionIndex.Value];
                    var target = dest.KeyPropositions[krDto.TargetKeyPropositionIndex.Value];
                    if (source.Id == 0) kr.SourceKeyProposition = source;
                    else kr.SourceKeyPropositionId = source.Id;
                    if (target.Id == 0) kr.TargetKeyProposition = target;
                    else kr.TargetKeyPropositionId = target.Id;
                }
            })
            .ReverseMap();
        CreateMap<KeyPropositionDto, KeyProposition>().ReverseMap()
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level.ToString()));
        CreateMap<BoundaryConditionDto, BoundaryCondition>().ReverseMap()
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level.ToString()));
        CreateMap<CommonMisconceptionDto, CommonMisconception>().ReverseMap();
        CreateMap<KeyRelationDto, KeyRelation>()
            .ForMember(d => d.SourceKeyProposition, opt => opt.Ignore())
            .ForMember(d => d.TargetKeyProposition, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level.ToString()))
            .ForMember(d => d.SourceKeyPropositionIndex, opt => opt.Ignore())
            .ForMember(d => d.TargetKeyPropositionIndex, opt => opt.Ignore());
    }
}
