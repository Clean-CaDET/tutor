using FluentResults;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.UseCases.Monitoring;

public class MasteryFactoryService : IMasteryFactory
{
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly IKnowledgeMasteryRepository _masteryRepository;
    private readonly IKnowledgeComponentsUnitOfWork _unitOfWork;


    public MasteryFactoryService(IKnowledgeComponentRepository kcRepository,
        IKnowledgeMasteryRepository masteryRepository, IKnowledgeComponentsUnitOfWork unitOfWork)
    {
        _kcRepository = kcRepository;
        _masteryRepository = masteryRepository;
        _unitOfWork = unitOfWork;
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
}