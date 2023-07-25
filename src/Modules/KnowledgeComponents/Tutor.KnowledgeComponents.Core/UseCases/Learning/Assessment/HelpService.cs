using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.UseCases.Learning.Assessment;

public class HelpService : IHelpService
{
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HelpService(IKnowledgeMasteryRepository knowledgeMasteryRepository, IUnitOfWork unitOfWork)
    {
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _unitOfWork = unitOfWork;
    }

    public Result RecordHintRequest(int learnerId, int assessmentItemId)
    {
        var kcm = _knowledgeMasteryRepository.GetFullByAssessmentItem(assessmentItemId, learnerId);
        if (kcm == null) return Result.Fail(FailureCode.NotFound);

        var result = kcm.RecordAssessmentItemHintRequest(assessmentItemId, "");

        if (result.IsSuccess) _knowledgeMasteryRepository.Update(kcm);
        result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return result;
    }

    // Temporary feature.
    public Result RecordInstructorMessage(int learnerId, int kcId, string message)
    {
        var kcm = _knowledgeMasteryRepository.GetBare(kcId, learnerId);
        if (kcm == null) return Result.Fail(FailureCode.NotEnrolledInUnit);

        var result = kcm.RecordInstructorMessage(message);

        if (result.IsSuccess) _knowledgeMasteryRepository.Update(kcm);
        result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return result;
    }
}