using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.UseCases.Learning;

public class InstructionService : IInstructionService
{
    private readonly IMapper _mapper;
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAccessService _accessService;
    private readonly IInstructionalItemRepository _instructionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InstructionService(IMapper mapper, IKnowledgeMasteryRepository knowledgeMasteryRepository, IAccessService accessService, IInstructionalItemRepository instructionRepository, IKnowledgeComponentsUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _accessService = accessService;
        _instructionRepository = instructionRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<List<InstructionalItemDto>> GetByKc(int kcId, int learnerId)
    {
        if (!_accessService.IsEnrolledInKc(kcId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var instruction = _instructionRepository.GetByKc(kcId);
        if (instruction == null) return Result.Fail(FailureCode.NotFound);

        RecordInstructionalItemSelection(kcId, learnerId);

        return instruction.OrderBy(i => i.Order)
            .Select(_mapper.Map<InstructionalItemDto>).ToList();
    }

    private void RecordInstructionalItemSelection(int knowledgeComponentId, int learnerId)
    {
        var kcMastery = _knowledgeMasteryRepository.GetBare(knowledgeComponentId, learnerId);
        kcMastery.RecordInstructionalItemSelection();
        _knowledgeMasteryRepository.Update(kcMastery);
        _unitOfWork.Save();
    }
}