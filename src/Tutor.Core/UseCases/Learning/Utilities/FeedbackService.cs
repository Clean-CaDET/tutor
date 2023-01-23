using FluentResults;
using System.Xml.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Core.UseCases.Learning.Utilities;

public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
    {
        _feedbackRepository = feedbackRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback)
    {
        if (emotionsFeedback.Comment == null)
            return Result.Fail("Empty Emotions Feedback");

        _feedbackRepository.SaveEmotionsFeedback(emotionsFeedback);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(emotionsFeedback);
    }

    public Result<TutorImprovementFeedback> SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback)
    {
        if (tutorImprovementFeedback.SoftwareComment == null)
            return Result.Fail("Empty Software Feedback");

        if (tutorImprovementFeedback.ContentComment == null)
            return Result.Fail("Empty Content Feedback");

        _feedbackRepository.SaveTutorImprovementFeedback(tutorImprovementFeedback);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(tutorImprovementFeedback);
    }
}