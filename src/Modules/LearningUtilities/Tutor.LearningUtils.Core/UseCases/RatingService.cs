using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningUtils.API.Dtos;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.LearningUtils.Core.Domain;
using Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningUtils.Core.UseCases;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public RatingService(IRatingRepository ratingRepository, ILearningUtilitiesUnitOfWork unitOfWork, IMapper mapper)
    {
        _ratingRepository = ratingRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<KnowledgeComponentRatingDto> RateKnowledgeComponent(KnowledgeComponentRatingDto kcRating)
    {
        _ratingRepository.RateKnowledgeComponent(_mapper.Map<KnowledgeComponentRatingDto, KnowledgeComponentRating>(kcRating));
        var result = _unitOfWork.Save();
        return result.IsFailed ? result : Result.Ok(kcRating);
    }
}