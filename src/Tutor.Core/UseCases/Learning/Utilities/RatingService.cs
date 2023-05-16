using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Core.UseCases.Learning.Utilities;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public RatingService(IRatingRepository ratingRepository, IUnitOfWork unitOfWork)
    {
        _ratingRepository = ratingRepository;
        _unitOfWork = unitOfWork;
    }
    
    public Result<KnowledgeComponentRating> RateKnowledgeComponent(KnowledgeComponentRating kcRating)
    {
        _ratingRepository.RateKnowledgeComponent(kcRating);
        
        var result = _unitOfWork.Save();
        return result.IsFailed ? result : Result.Ok(kcRating);
    }
}