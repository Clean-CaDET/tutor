using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Analysis;

public interface IUnitProgressRatingService
{
    Result<UnitFeedbackRequestDto> ShouldRequestFeedback(int unitId, int learnerId);
    Result<UnitProgressRatingDto> Create(UnitProgressRatingDto rating, int learnerId);
}