using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.KnowledgeAnalysis
{
    public interface IUnitAnalysisService
    {
        Result<List<KcStatistics>> GetKnowledgeComponentsStats(int unitId, int instructorId);
        Result<List<KcStatistics>> GetKnowledgeComponentsStatsForGroup(int unitId, int groupId, int instructorId);
    }
}
