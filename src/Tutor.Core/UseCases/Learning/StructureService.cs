using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning;

public class StructureService : IStructureService
{
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IKnowledgeComponentRepository _knowledgeComponentRepository;
    private readonly IUnitRepository _unitRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StructureService(IKnowledgeMasteryRepository knowledgeMasteryRepository, IEnrollmentRepository enrollmentRepository, IKnowledgeComponentRepository knowledgeComponentRepository, IUnitRepository unitRepository, IUnitOfWork unitOfWork)
    {
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _enrollmentRepository = enrollmentRepository;
        _knowledgeComponentRepository = knowledgeComponentRepository;
        _unitRepository = unitRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<KnowledgeUnit> GetUnit(int unitId, int learnerId)
    {
        if(!_enrollmentRepository.HasActiveEnrollmentForUnit(unitId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);
        return Result.Ok(_unitRepository.GetUnitWithKcs(unitId));
    }

    public Result<List<KnowledgeComponentMastery>> GetMasteries(int unitId, int learnerId)
    {
        if (!_enrollmentRepository.HasActiveEnrollmentForUnit(unitId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcs = _knowledgeComponentRepository.GetKnowledgeComponentsForUnit(unitId);
        var kcIds = kcs.Select(kc => kc.Id).ToList();

        return Result.Ok(_knowledgeMasteryRepository.GetBasicKcMasteries(kcIds, learnerId));
    }

    public Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId)
    {
        if (!_enrollmentRepository.HasActiveEnrollmentForKc(knowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);
        
        var kc = _knowledgeComponentRepository.GetKnowledgeComponentWithInstruction(knowledgeComponentId);
        if (kc == null) return Result.Fail(FailureCode.NotFound);

        return Result.Ok(kc);
    }

    public Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId)
    {
        if (!_enrollmentRepository.HasActiveEnrollmentForKc(knowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kc = _knowledgeComponentRepository.GetKnowledgeComponentWithInstruction(knowledgeComponentId);
        if (kc == null) return Result.Fail(FailureCode.NotFound);

        RecordInstructionalItemSelection(knowledgeComponentId, learnerId);

        return Result.Ok(kc.GetOrderedInstructionalItems());
    }

    private void RecordInstructionalItemSelection(int knowledgeComponentId, int learnerId)
    {
        var kcMastery = _knowledgeMasteryRepository.GetBareKcMastery(knowledgeComponentId, learnerId);
        kcMastery.RecordInstructionalItemSelection();
        _knowledgeMasteryRepository.UpdateKcMastery(kcMastery);
        _unitOfWork.Save();
    }
}