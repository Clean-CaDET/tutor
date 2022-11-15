using AutoMapper;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Web.Mappings.KnowledgeMastery
{
    public class MasteryProfile : Profile
    {
        public MasteryProfile()
        {
            CreateMap<KnowledgeComponentMastery, KnowledgeComponentMasteryDto>();
            CreateMap<AssessmentItemMastery, AssessmentItemMasteryDto>();
            CreateMap<KcMasteryStatistics, KcMasteryStatisticsDto>();
        }
    }
}