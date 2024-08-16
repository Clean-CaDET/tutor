using AutoMapper;
using FluentResults;
using System.Threading.Tasks;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.UseCases.Learning;

public class StructureService : IStructureService, IKnowledgeMasteryQuerier
{
    private readonly IMapper _mapper;
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAccessService _accessService;
    private readonly IKnowledgeComponentRepository _knowledgeComponentRepository;

    public StructureService(IMapper mapper, IKnowledgeMasteryRepository knowledgeMasteryRepository, IAccessService accessService, IKnowledgeComponentRepository knowledgeComponentRepository)
    {
        _mapper = mapper;
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _accessService = accessService;
        _knowledgeComponentRepository = knowledgeComponentRepository;
    }

    public Result<List<int>> GetMasteredUnitIds(List<int> unitIds, int learnerId)
    {
        var rootKcs = _knowledgeComponentRepository.GetRootKcs(unitIds);
        var unitIdsWithoutRootKcs = unitIds.Where(id => rootKcs.All(kc => kc.KnowledgeUnitId != id));

        var masteries = _knowledgeMasteryRepository
            .GetBareByKcs(rootKcs.Select(kc => kc.Id).ToList(), learnerId);
        var masteredRootKcs = GetMasteredKcs(rootKcs, masteries);

        return masteredRootKcs
            .Select(kc => kc.KnowledgeUnitId)
            .Concat(unitIdsWithoutRootKcs)
            .ToList();
    }

    private static List<KnowledgeComponent> GetMasteredKcs(List<KnowledgeComponent> rootKcs, List<KnowledgeComponentMastery> masteries)
    {
        var masteredKcIds = masteries.Where(m => m.IsSatisfied).Select(m => m.KnowledgeComponentId);
        return rootKcs.Where(kc => masteredKcIds.Contains(kc.Id)).ToList();
    }

    public Result<List<KcWithMasteryDto>> GetKcsWithMasteries(int unitId, int learnerId)
    {
        if(!_accessService.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcs = _knowledgeComponentRepository.GetByUnit(unitId);
        var kcIds = kcs.Select(kc => kc.Id).ToList();
        var masteries = _knowledgeMasteryRepository.GetBareByKcs(kcIds, learnerId);

        return MapToDto(kcs, masteries);
    }

    private Result<List<KcWithMasteryDto>> MapToDto(List<KnowledgeComponent> kcs, List<KnowledgeComponentMastery> masteries)
    {
        var retVal = new List<KcWithMasteryDto>();
        kcs.ForEach(kc =>
        {
            retVal.Add(new KcWithMasteryDto
            {
                KnowledgeComponent = _mapper.Map<KnowledgeComponentDto>(kc),
                Mastery = _mapper.Map<KnowledgeComponentMasteryDto>(masteries.Find(m => m.KnowledgeComponentId == kc.Id))
            });
        });

        return retVal;
    }

    public Result<KnowledgeComponentDto> GetKnowledgeComponent(int kcId, int learnerId)
    {
        if (!_accessService.IsEnrolledInKc(kcId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);
        
        var kc = _knowledgeComponentRepository.Get(kcId);
        if (kc == null) return Result.Fail(FailureCode.NotFound);

        return _mapper.Map<KnowledgeComponentDto>(kc);
    }

    public Result<Tuple<int, int>> CountTotalAndSatisfied(int unitId, int learnerId)
    {
        var kcs = _knowledgeComponentRepository.GetByUnit(unitId);
        var kcIds = kcs.Select(kc => kc.Id).ToList();
        var masteries = _knowledgeMasteryRepository.GetBareByKcs(kcIds, learnerId);

        return new Tuple<int, int>(masteries.Count, masteries.Count(m => m.IsSatisfied));
    }
}