using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Monitoring;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.UseCases.Monitoring;

public class LearnerProgressService : ILearnerProgressService
{
    private readonly IKnowledgeMasteryRepository _masteryRepository;
    private readonly IAccessService _accessService;

    public LearnerProgressService(IKnowledgeMasteryRepository masteryRepository, IAccessService accessService)
    {
        _masteryRepository = masteryRepository;
        _accessService = accessService;
    }

    public Result<List<KnowledgeComponentMasteryDto>> GetProgress(int unitId, int[] learnerIds, int instructorId)
    {
        if (learnerIds.Length == 0) return Result.Fail(FailureCode.NotFound);
        if (!_accessService.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return _masteryRepository.GetByLearnersAndUnit(unitId, learnerIds);
    }
}