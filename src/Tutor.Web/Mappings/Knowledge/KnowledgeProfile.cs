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
        CreateMap<CourseDto, Course>();
        CreateMap<Course, CourseDto>();
        CreateMap<KnowledgeUnit, KnowledgeUnitDto>();
        CreateMap<KnowledgeUnitDto, KnowledgeUnit>();
        CreateMap<KnowledgeComponent, KnowledgeComponentDto>();
        CreateMap<KnowledgeComponentDto, KnowledgeComponent>();

        CreateMap<KcStatistics, KcStatisticsDto>();

        CreateMap<InstructionalItem, InstructionalItemDto>().IncludeAllDerived();
        CreateMap<Markdown, TextDto>();
        CreateMap<Image, ImageDto>();
        CreateMap<Video, VideoDto>();
    }
}