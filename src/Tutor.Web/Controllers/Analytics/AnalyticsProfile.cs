using AutoMapper;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

namespace Tutor.Web.Controllers.Analytics
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
                .ForMember(dest => dest.AssessmentItemMasteries, opt => opt.MapFrom(src => src.AssessmentMasteries))
                .ForMember(dest => dest.Statistics, opt => opt.MapFrom(src => src.Statistics));
        }
    }
}
