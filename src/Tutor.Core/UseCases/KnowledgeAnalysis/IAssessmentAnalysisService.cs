using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.KnowledgeAnalysis;

namespace Tutor.Core.UseCases.KnowledgeAnalysis;

public interface IAssessmentAnalysisService
{
    Result<List<AiStatistics>> GetStatistics(int kcId, int instructorId);
    Result<List<AiStatistics>> GetStatisticsForGroup(int kcId, int groupId, int instructorId);
}