using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.API.Public.Learning;

public interface IStatisticsService
{
    Result<KcMasteryStatisticsDto> GetKcMasteryStatistics(int knowledgeComponentId, int learnerId);
    Result<double> GetMaxAssessmentCorrectness(int assessmentItemId, int learnerId);
}