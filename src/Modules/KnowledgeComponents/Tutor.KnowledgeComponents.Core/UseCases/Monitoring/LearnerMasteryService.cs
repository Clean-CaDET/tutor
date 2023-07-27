using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Monitoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.UseCases.Monitoring;

public class LearnerMasteryService : ILearnerMasteryService
{
    private readonly IMapper _mapper;
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly IKnowledgeMasteryRepository _masteryRepository;
    private readonly IAccessService _accessService;
    private readonly IKnowledgeComponentsUnitOfWork _unitOfWork;

    public LearnerMasteryService(IMapper mapper, IKnowledgeComponentRepository kcRepository,
        IKnowledgeMasteryRepository masteryRepository, IAccessService accessService, IKnowledgeComponentsUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _kcRepository = kcRepository;
        _masteryRepository = masteryRepository;
        _accessService = accessService;
        _unitOfWork = unitOfWork;
    }

    public Result InitializeMasteries(int unitId, int learnerId)
    {
        CreateMasteries(unitId, learnerId);
        return _unitOfWork.Save();
    }

    public Result InitializeMasteries(int unitId, int[] learnerIds)
    {
        Array.ForEach(learnerIds, learnerId => CreateMasteries(unitId, learnerId));
        return _unitOfWork.Save();
    }

    private void CreateMasteries(int unitId, int learnerId)
    {
        var kcs = _kcRepository.GetByUnitWithAssessments(unitId);
        foreach (var kc in kcs)
        {
            var assessmentMasteries = kc.AssessmentItems?
                .OrderBy(i => i.Order)
                .Select(item => new AssessmentItemMastery(item.Id)).ToList();
            var kcMastery = new KnowledgeComponentMastery(learnerId, kc.Id, assessmentMasteries);
            _masteryRepository.Create(kcMastery);
        }
    }

    public Result<List<KcmProgressDto>> GetProgress(int unitId, int[] learnerIds, int instructorId)
    {
        if (learnerIds.Length == 0) return Result.Fail(FailureCode.NotFound);
        if (!_accessService.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return _masteryRepository.GetByLearnersAndUnit(unitId, learnerIds)
            .Select(_mapper.Map<KcmProgressDto>).ToList();
    }
}