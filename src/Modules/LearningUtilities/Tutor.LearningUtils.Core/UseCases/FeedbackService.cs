using AutoMapper;
using FluentResults;
using Tutor.LearningUtils.API.Dtos.Feedback;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.LearningUtils.Core.Domain;
using Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningUtils.Core.UseCases;

public class FeedbackService : IFeedbackService
{
    
    private readonly IMapper _mapper;
    private readonly IFeedbackRepository _repository;
    private readonly ILearningUtilsUnitOfWork _unitOfWork;

    public FeedbackService(IMapper mapper, IFeedbackRepository repository, ILearningUtilsUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public Result<EmotionsFeedbackDto> SaveEmotionsFeedback(EmotionsFeedbackDto emotionsFeedback)
    {
        _repository.SaveEmotionsFeedback(_mapper.Map<EmotionsFeedbackDto, EmotionsFeedback>(emotionsFeedback));
        var result = _unitOfWork.Save();
        return result.IsFailed ? result : Result.Ok(emotionsFeedback);
    }

    public Result<ImprovementFeedbackDto> SaveTutorImprovementFeedback(ImprovementFeedbackDto tutorImprovementFeedback)
    {
        _repository.SaveTutorImprovementFeedback(_mapper.Map<ImprovementFeedbackDto, ImprovementFeedback>(tutorImprovementFeedback));
        var result = _unitOfWork.Save();
        return result.IsFailed ? result : Result.Ok(tutorImprovementFeedback);
    }
}