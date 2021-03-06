using AutoMapper;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ArrangeTasks;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ShortAnswerQuestions;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalItems;

namespace Tutor.Web.Controllers.Domain
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<KnowledgeUnit, UnitDto>()
                .ForMember(dest => dest.KnowledgeComponents, opt => opt.MapFrom(src => src.KnowledgeComponents.Where(kc => kc.ParentId == null || kc.ParentId == 0)));
            CreateMap<KnowledgeComponent, KnowledgeComponentDto>();

            CreateMap<InstructionalItem, InstructionalItemDto>().IncludeAllDerived();
            CreateMap<Markdown, TextDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<Video, VideoDto>();

            CreateMap<AssessmentItem, AssessmentItemDto>().IncludeAllDerived();
            CreateMap<Challenge, ChallengeDto>();
            CreateMap<Mrq, MrqDto>();
            CreateMap<MrqItem, MrqItemDto>();
            CreateMap<ArrangeTask, AtDto>()
                .ForMember(dest => dest.UnarrangedElements, opt => opt.MapFrom(src => src.Containers.SelectMany(c => c.Elements).ToList()));
            CreateMap<ArrangeTaskContainer, AtContainerDto>();
            CreateMap<ArrangeTaskElement, AtElementDto>();
            CreateMap<Saq, SaqDto>();
        }
    }
}