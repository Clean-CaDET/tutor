using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Learning;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning")]
public class ReflectionController : BaseApiController
{
    private readonly IReflectionService _reflectionService;

    public ReflectionController(IReflectionService reflectionService)
    {
        _reflectionService = reflectionService;
    }

    [HttpGet("units/{unitId:int}/reflections")]
    public ActionResult<List<ReflectionDto>> GetAll(int unitId)
    {
        var result = _reflectionService.GetAll(unitId, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpGet("reflections/{id:int}")]
    public ActionResult<ReflectionDto> Get(int id)
    {
        var result = _reflectionService.GetWithSubmission(id, User.LearnerId());
        return CreateResponse(result);
    }

    [HttpPost("reflections/{id:int}/answer")]
    public ActionResult SubmitAnswer(int id, [FromBody] ReflectionAnswerDto answer)
    {
        var result = _reflectionService.SubmitAnswer(id, User.LearnerId(), answer);
        return CreateResponse(result);
    }
}
