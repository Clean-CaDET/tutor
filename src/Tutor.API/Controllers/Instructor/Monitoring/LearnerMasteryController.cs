using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring")]
public class LearnerMasteryController : BaseApiController
{
    private readonly ILearnerMasteryService _masteryService;

    public LearnerMasteryController(ILearnerMasteryService masteryService)
    {
        _masteryService = masteryService;
    }

    [HttpGet("progress/{unitId:int}")]
    public ActionResult<List<KcmProgressDto>> GetLearnerProgress(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _masteryService.GetProgress(unitId, learnerIds, User.InstructorId());
        return CreateResponse(result);
    }
}