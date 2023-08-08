using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.API.Public.Monitoring;

public interface ILearnerMasteryService
{
    Result<List<KcmProgressDto>> GetProgress(int unitId, int[] learnerIds, int instructorId);
}