using AutoMapper;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;

namespace Tutor.KnowledgeComponents.Core.Mappers;

public class KnowledgeProfile : Profile
{
    public KnowledgeProfile()
    {
        CreateMap<KnowledgeComponent, KnowledgeComponentDto>();
        CreateMap<KnowledgeComponentDto, KnowledgeComponent>();

        CreateMap<InstructionalItem, InstructionalItemDto>().IncludeAllDerived();
        CreateMap<Markdown, TextDto>();
        CreateMap<Image, ImageDto>();
        CreateMap<Video, VideoDto>();

        CreateMap<InstructionalItemDto, InstructionalItem>().IncludeAllDerived();
        CreateMap<TextDto, Markdown>();
        CreateMap<ImageDto, Image>();
        CreateMap<VideoDto, Video>();
    }
}