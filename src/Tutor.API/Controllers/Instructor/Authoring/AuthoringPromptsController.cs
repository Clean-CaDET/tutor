using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.Core.Domain;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Route("api/authoring/prompts")]
[Authorize(Policy = "instructorPolicy")]
public class AuthoringPromptsController : BaseApiController
{
    private readonly ICrudRepository<SystemPrompt> _promptRepository;

    public AuthoringPromptsController(ICrudRepository<SystemPrompt> promptRepository)
    {
        _promptRepository = promptRepository;
    }

    [HttpGet]
    public ActionResult<List<SystemPrompt>> GetAll()
    {
        var results = _promptRepository.GetPaged(0, 0);
        return Ok(results.Results);
    }
}