using System.Linq;
using AutoMapper;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems;

namespace Tutor.Web.Mappings.Knowledge;

public class KnowledgeProfile : Profile
{
    public KnowledgeProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<KnowledgeUnit, KnowledgeUnitDto>()
            .ForMember(dest => dest.KnowledgeComponents, opt => opt.MapFrom(src => src.KnowledgeComponents.Where(kc => kc.ParentId == null || kc.ParentId == 0)));
        CreateMap<KnowledgeComponent, KnowledgeComponentDto>();

        CreateMap<KcStatistics, KcStatisticsDto>();

        CreateMap<InstructionalItem, InstructionalItemDto>().IncludeAllDerived();
        CreateMap<Markdown, TextDto>();
        CreateMap<Image, ImageDto>();
        CreateMap<Video, VideoDto>();
    }
}