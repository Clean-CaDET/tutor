using AutoMapper;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.Mappers;

public class MasteryProfile : Profile
{
    public MasteryProfile()
    {
        CreateMap<KnowledgeComponentMastery, KnowledgeComponentMasteryDto>();
        CreateMap<AssessmentItemMastery, AssessmentItemMasteryDto>();
        
        CreateMap<KcMasteryStatistics, KcMasteryStatisticsDto>();
    }
}