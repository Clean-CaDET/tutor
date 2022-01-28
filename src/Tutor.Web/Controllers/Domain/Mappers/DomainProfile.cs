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
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ShortAnswerQuestion;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;

namespace Tutor.Web.Controllers.Domain.Mappers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<KnowledgeComponent, KnowledgeComponentDto>()
                .ForMember(dest => dest.Mastery, opt => opt.MapFrom(src => src.Masteries.FirstOrDefault()));
            CreateMap<KnowledgeComponentMastery, KnowledgeComponentMasteryDto>();

            CreateMap<InstructionalEvent, InstructionalEventDto>().IncludeAllDerived();
            CreateMap<Text, TextDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<Video, VideoDto>();

            CreateMap<AssessmentEvent, AssessmentEventDto>().IncludeAllDerived();
            CreateMap<Challenge, ChallengeDto>();
            CreateMap<Mrq, MultiResponseQuestionDto>();
            CreateMap<MrqItem, MrqItemDto>();
            CreateMap<ArrangeTask, ArrangeTaskDto>()
                .ForMember(dest => dest.UnarrangedElements, opt => opt.MapFrom(src => src.Containers.SelectMany(c => c.Elements).ToList()));
            CreateMap<ArrangeTaskContainer, ArrangeTaskContainerDto>();
            CreateMap<ArrangeTaskElement, ArrangeTaskElementDto>();
            CreateMap<Saq, ShortAnswerQuestionDto>();
        }
    }
}