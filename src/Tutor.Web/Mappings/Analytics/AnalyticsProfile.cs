using AutoMapper;
using Tutor.Core.Domain.KnowledgeAnalysis;

namespace Tutor.Web.Mappings.Analytics;

public class AnalyticsProfile : Profile
{
    public AnalyticsProfile()
    {
        CreateMap<KcStatistics, KcStatisticsDto>();
        CreateMap<AiStatistics, AiStatisticsDto>();
    }
}