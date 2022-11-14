using AutoMapper;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Web.Mappings.Mastery
{
    public class KcMasteryProfile : Profile
    {
        public KcMasteryProfile()
        {
            CreateMap<KnowledgeComponentMastery, KnowledgeComponentMasteryDto>();
            CreateMap<AssessmentItemMastery, AssessmentItemMasteryDto>();
            CreateMap<KcMasteryStatistics, KcMasteryStatisticsDto>();
        }
    }
}