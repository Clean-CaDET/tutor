using AutoMapper;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Web.Mappings.Analytics
{
    public class AnalyticsProfile : Profile
    {
        public AnalyticsProfile()
        {
            CreateMap<Learner, LearnerProgressDto>()
                .ForMember(dest => dest.Learner, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.KnowledgeComponentProgress,
                    opt => opt.MapFrom(src => src.KnowledgeComponentMasteries));

            CreateMap<KnowledgeComponentMastery, KcmProgressDto>()
                .ForMember(dest => dest.KcId, opt => opt.MapFrom(src => src.KnowledgeComponent.Id))
                .ForMember(dest => dest.KcCode, opt => opt.MapFrom(src => src.KnowledgeComponent.Code))
                .ForMember(dest => dest.KcName, opt => opt.MapFrom(src => src.KnowledgeComponent.Name))
                .ForMember(dest => dest.KcUnitId, opt => opt.MapFrom(src => src.KnowledgeComponent.KnowledgeUnitId))
                .ForMember(dest => dest.AssessmentItemMasteries, opt => opt.MapFrom(src => src.AssessmentItemMasteries))
                .ForMember(dest => dest.Statistics, opt => opt.MapFrom(src => src.Statistics))
                .ForMember(dest => dest.DurationOfFinishedSessionsInMinutes, opt => opt.MapFrom(src =>
                    (src.SessionTracker.DurationOfFinishedSessions.Hours * 60) + src.SessionTracker.DurationOfFinishedSessions.Minutes))
                .ForMember(dest => dest.ExpectedDurationInMinutes, opt => opt.MapFrom(src => src.KnowledgeComponent.ExpectedDurationInMinutes));
        }
    }
}
