using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Analysis;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Analytics;

[Authorize(Policy = "learnerPolicy")]
[Route("api/analysis/rating/units")]
public class UnitProgressRatingController : BaseApiController
{
    private readonly IUnitProgressRatingService _ratingService;
    public UnitProgressRatingController(IUnitProgressRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpGet("{unitId:int}")]
    public ActionResult<UnitFeedbackRequestDto> ShouldRequestFeedback(int unitId)
    {
        var result = _ratingService.ShouldRequestFeedback(unitId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<UnitProgressRatingDto> Rate([FromBody] UnitProgressRatingDto rating)
    {
        var result = _ratingService.Create(rating, User.LearnerId());
        return CreateResponse(result);
    }
}