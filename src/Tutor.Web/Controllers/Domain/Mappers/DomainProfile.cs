using AutoMapper;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentEvents.ShortAnswerQuestions;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTasks;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenges;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ShortAnswerQuestions;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;
using KnowledgeComponentStatistics = Tutor.Core.DomainModel.KnowledgeComponents.KnowledgeComponentStatistics;

namespace Tutor.Web.Controllers.Domain.Mappers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<KnowledgeComponent, KnowledgeComponentDto>()
                .ForMember(dest => dest.Mastery, opt => opt.MapFrom(src => src.KnowledgeComponentMasteries.FirstOrDefault()));
            CreateMap<KnowledgeComponentMastery, KnowledgeComponentMasteryDto>();
            CreateMap<KnowledgeComponentStatistics, KnowledgeComponentStatisticsDto>();

            CreateMap<InstructionalEvent, InstructionalEventDto>().IncludeAllDerived();
            CreateMap<Text, TextDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<Video, VideoDto>();

            CreateMap<AssessmentEvent, AssessmentEventDto>().IncludeAllDerived();
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