
using FluentResults;
using Tutor.LearningUtils.API.Dtos;

namespace Tutor.LearningUtils.API.Interfaces
{
    public interface IRatingService
    {
        Result<RatingDto> RateKnowledgeComponent(RatingDto kcRating);
    }
}
