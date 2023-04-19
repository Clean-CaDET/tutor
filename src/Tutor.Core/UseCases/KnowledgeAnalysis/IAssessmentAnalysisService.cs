using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.KnowledgeAnalysis;

namespace Tutor.Core.UseCases.KnowledgeAnalysis;

public interface IAssessmentAnalysisService
{
    Result<List<AiStatistics>> GetAiStatistics(int kcId, int instructorId);
    Result<List<AiStatistics>> GetAiStatisticsForGroup(int kcId, int groupId, int instructorId);
}