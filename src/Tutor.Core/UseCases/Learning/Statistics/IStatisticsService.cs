using FluentResults;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning.Statistics;

public interface IStatisticsService
{
    Result<KcMasteryStatistics> GetKcMasteryStatistics(int knowledgeComponentId, int learnerId);
    Result<double> GetMaxAssessmentCorrectness(int learnerId, int assessmentItemId);
}