using AutoMapper;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;

namespace Tutor.Web.Controllers.Domain.Mappers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Unit, UnitDTO>()
                .ForMember(dest => dest.KnowledgeComponentIds,
                    opt => opt.MapFrom(src => src.KnowledgeComponents.Select(n => n.Id)));
            CreateMap<KnowledgeComponent, KnowledgeComponentDTO>();

            CreateMap<InstructionalEvent, InstructionalEventDTO>().IncludeAllDerived();
            CreateMap<Text, TextDTO>();
            CreateMap<Image, ImageDTO>();
            CreateMap<Video, VideoDTO>();

            CreateMap<AssessmentEvent, AssessmentEventDTO>().IncludeAllDerived();
            CreateMap<Challenge, ChallengeDTO>();
            CreateMap<MRQContainer, MultiResponseQuestionDTO>();
            CreateMap<MRQAnswer, MRQAnswerDTO>();
            CreateMap<ArrangeTask, ArrangeTaskDTO>()
                .ForMember(dest => dest.UnarrangedElements, opt => opt.MapFrom(src => src.Containers.SelectMany(c => c.Elements).ToList()));
            CreateMap<ArrangeTaskContainer, ArrangeTaskContainerDTO>();
            CreateMap<ArrangeTaskElement, ArrangeTaskElementDTO>();
        }
    }
}