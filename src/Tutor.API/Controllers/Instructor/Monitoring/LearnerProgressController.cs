using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring")]
public class LearnerProgressController : BaseApiController
{
    private readonly ILearnerProgressService _progressService;

    public LearnerProgressController(ILearnerProgressService progressService)
    {
        _progressService = progressService;
    }

    [HttpGet("progress/{unitId:int}")]
    public ActionResult<List<KcmProgressDto>> GetLearnerProgress(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _progressService.GetProgress(unitId, learnerIds, User.InstructorId());
        return CreateResponse(result);
    }
}