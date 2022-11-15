using AutoMapper;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Web.Mappings.KnowledgeMastery
{
    public class KnowledgeMasteryProfile : Profile
    {
        public KnowledgeMasteryProfile()
        {
            CreateMap<KnowledgeComponentMastery, KnowledgeComponentMasteryDto>();
            CreateMap<AssessmentItemMastery, AssessmentItemMasteryDto>();
            CreateMap<KcMasteryStatistics, KcMasteryStatisticsDto>();
        }
    }
}