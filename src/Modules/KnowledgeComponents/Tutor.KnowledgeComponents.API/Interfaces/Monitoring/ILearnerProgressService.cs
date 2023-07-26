using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.API.Interfaces.Monitoring;

public interface ILearnerProgressService
{
    Result<List<KcmProgressDto>> GetProgress(int unitId, int[] learnerIds, int instructorId);
}