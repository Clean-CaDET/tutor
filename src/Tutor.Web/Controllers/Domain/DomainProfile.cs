using AutoMapper;
using System.Linq;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalItems;

namespace Tutor.Web.Controllers.Domain
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