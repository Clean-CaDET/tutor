using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.API.Interfaces.Monitoring;

public interface ILearnerMasteryService
{
    Result InitializeMasteries(int unitId, int learnerId);
    Result InitializeMasteries(int unitId, int[] learnerIds);
    Result<List<KcmProgressDto>> GetProgress(int unitId, int[] learnerIds, int instructorId);
}