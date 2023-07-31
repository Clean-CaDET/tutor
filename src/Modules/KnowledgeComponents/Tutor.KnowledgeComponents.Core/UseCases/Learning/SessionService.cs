using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.UseCases.Learning;

public class SessionService : ISessionService
{
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAccessService _accessService;
    private readonly IUnitOfWork _unitOfWork;

    public SessionService(IKnowledgeMasteryRepository kcMasteryRepository, IAccessService accessService, IKnowledgeComponentsUnitOfWork unitOfWork)
    {
        _knowledgeMasteryRepository = kcMasteryRepository;
        _accessService = accessService;
        _unitOfWork = unitOfWork;
    }

    public Result LaunchSession(int knowledgeComponentId, int learnerId)
    {
        var result = TryGetKcMastery(knowledgeComponentId, learnerId);
        if (result.IsFailed) return result.ToResult();

        var kcMastery = result.Value;
        kcMastery.LaunchSession();

        _knowledgeMasteryRepository.Update(kcMastery);
        return _unitOfWork.Save();
    }

    public Result TerminateSession(int knowledgeComponentId, int learnerId)
    {
        var kcMasteryResult = TryGetKcMastery(knowledgeComponentId, learnerId);
        if (kcMasteryResult.IsFailed) return kcMasteryResult.ToResult();

        var kcMastery = kcMasteryResult.Value;
        var result = kcMastery.TerminateSession();
        if (result.IsFailed) return result;

        _knowledgeMasteryRepository.Update(kcMastery);
        return _unitOfWork.Save();
    }

    public Result PauseSession(int knowledgeComponentId, int learnerId)
    {
        var kcMasteryResult = TryGetKcMastery(knowledgeComponentId, learnerId);
        if (kcMasteryResult.IsFailed) return kcMasteryResult.ToResult();

        var kcMastery = kcMasteryResult.Value;
        var result = kcMastery.PauseSession();

        if (result.IsFailed) return result;
        _knowledgeMasteryRepository.Update(kcMastery);
        return _unitOfWork.Save();
    }

    public Result ContinueSession(int knowledgeComponentId, int learnerId)
    {
        var kcMasteryResult = TryGetKcMastery(knowledgeComponentId, learnerId);
        if (kcMasteryResult.IsFailed) return kcMasteryResult.ToResult();

        var kcMastery = kcMasteryResult.Value;
        var result = kcMastery.ContinueSession();
        if (result.IsFailed) return result;
        _knowledgeMasteryRepository.Update(kcMastery);
        return _unitOfWork.Save();
    }

    public Result AbandonSession(int knowledgeComponentId, int learnerId)
    {
        var kcMasteryResult = TryGetKcMastery(knowledgeComponentId, learnerId);
        if (kcMasteryResult.IsFailed) return kcMasteryResult.ToResult();

        var kcMastery = kcMasteryResult.Value;
        var result = kcMastery.AbandonSession();
        if (result.IsFailed) return result;
        _knowledgeMasteryRepository.Update(kcMastery);
        return _unitOfWork.Save();
    }

    private Result<KnowledgeComponentMastery> TryGetKcMastery(int knowledgeComponentId, int learnerId)
    {
        if (!_accessService.IsEnrolledInKc(knowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcMastery = _knowledgeMasteryRepository.GetBare(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail(FailureCode.NotFound);
        return kcMastery;
    }
}