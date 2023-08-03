using AutoMapper;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.Core.Mappers;

public class AnalyticsProfile : Profile
{
    public AnalyticsProfile()
    {
        CreateMap<KcStatistics, KcStatisticsDto>();
        CreateMap<AiStatistics, AiStatisticsDto>();
        CreateMap<KnowledgeComponentRatingDto, KnowledgeComponentRating>().ReverseMap();
    }
}