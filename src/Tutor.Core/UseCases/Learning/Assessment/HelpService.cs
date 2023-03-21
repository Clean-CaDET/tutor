﻿using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning.Assessment;

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
        var kcm = _knowledgeMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
        if (kcm == null) return Result.Fail("Cannot seek hints for assessment item with ID: " + assessmentItemId);

        var result = kcm.RecordAssessmentItemHintRequest(assessmentItemId, "");

        if (result.IsSuccess) _knowledgeMasteryRepository.UpdateKcMastery(kcm);
        result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return result;
    }

    public Result RecordSolutionRequest(int learnerId, int assessmentItemId)
    {
        var kcm = _knowledgeMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
        if (kcm == null) return Result.Fail("Cannot seek solution for assessment item with ID: " + assessmentItemId);

        var result = kcm.RecordAssessmentItemSolutionRequest(assessmentItemId);

        if (result.IsSuccess) _knowledgeMasteryRepository.UpdateKcMastery(kcm);
        result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return result;
    }

    //Should be moved to an instructor service or whatever will be used to interact with the chatbot
    public Result RecordInstructorMessage(int learnerId, int kcId, string message)
    {
        var kcm = _knowledgeMasteryRepository.GetBareKcMastery(kcId, learnerId);
        if (kcm == null) return Result.Fail("Learner not enrolled in KC: " + kcId);

        var result = kcm.RecordInstructorMessage(message);

        if (result.IsSuccess) _knowledgeMasteryRepository.UpdateKcMastery(kcm);
        result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return result;
    }
}