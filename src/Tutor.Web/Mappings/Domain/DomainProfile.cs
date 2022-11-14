using AutoMapper;
using System.Linq;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Web.Mappings.Domain.DTOs;
using Tutor.Web.Mappings.Domain.DTOs.InstructionalItems;

namespace Tutor.Web.Mappings.Domain
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<KnowledgeUnit, KnowledgeUnitDto>()
                .ForMember(dest => dest.KnowledgeComponents, opt => opt.MapFrom(src => src.KnowledgeComponents.Where(kc => kc.ParentId == null || kc.ParentId == 0)));
            CreateMap<KnowledgeComponent, KnowledgeComponentDto>();

            CreateMap<InstructionalItem, InstructionalItemDto>().IncludeAllDerived();
            CreateMap<Markdown, TextDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<Video, VideoDto>();
        }
    }
}