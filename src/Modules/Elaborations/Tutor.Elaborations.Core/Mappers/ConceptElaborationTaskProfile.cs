using AutoMapper;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.Mappers;

public class ConceptElaborationTaskProfile : Profile
{
    public ConceptElaborationTaskProfile()
    {
        CreateMap<ConceptElaborationTaskDto, ConceptElaborationTask>()
            .ForMember(d => d.UnitId, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(d => d.Attempts, opt => opt.Ignore());

        CreateMap<ConceptRecordDto, ConceptRecord>()
            .ForMember(d => d.ConceptElaborationTaskId, opt => opt.Ignore())
            .ForCtorParam("conceptElaborationTaskId", opt => opt.MapFrom(_ => 0))
            .ReverseMap();

        CreateMap<KeyPropositionDto, KeyProposition>().ReverseMap();
        CreateMap<CommonMisconceptionDto, CommonMisconception>().ReverseMap();
        CreateMap<KeyRelationDto, KeyRelation>().ReverseMap();
    }
}
