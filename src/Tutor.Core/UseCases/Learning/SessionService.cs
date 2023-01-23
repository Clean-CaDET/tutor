using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning;

public class SessionService : ISessionService
{
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SessionService(IKnowledgeMasteryRepository ikcMasteryRepository, IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork)
    {
        _knowledgeMasteryRepository = ikcMasteryRepository;
        _enrollmentRepository = enrollmentRepository;
        _unitOfWork = unitOfWork;
    }

    public Result LaunchSession(int knowledgeComponentId, int learnerId)
    {
        if (!_enrollmentRepository.HasActiveEnrollmentForKc(knowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcMastery = _knowledgeMasteryRepository.GetBareKcMastery(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail(FailureCode.NotFound);

        var result = kcMastery.LaunchSession();
        _knowledgeMasteryRepository.UpdateKcMastery(kcMastery);
        var saveResult = _unitOfWork.Save();
        if (saveResult.IsFailed) return saveResult;

        return result;
    }

    public Result TerminateSession(int knowledgeComponentId, int learnerId)
    {
        if (!_enrollmentRepository.HasActiveEnrollmentForKc(knowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcMastery = _knowledgeMasteryRepository.GetBareKcMastery(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail(FailureCode.NotFound);

        var result = kcMastery.TerminateSession();
        _knowledgeMasteryRepository.UpdateKcMastery(kcMastery);
        var saveResult = _unitOfWork.Save();
        if (saveResult.IsFailed) return saveResult;

        return result;
    }
}