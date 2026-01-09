using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Route("api/authoring/knowledge-components/{kcId:int}/index")]
[Authorize(Policy = "instructorPolicy")]
public class KnowledgeComponentIndexingController : BaseApiController
{
    private readonly IKnowledgeComponentIndexingService _indexingService;

    public KnowledgeComponentIndexingController(IKnowledgeComponentIndexingService indexingService)
    {
        _indexingService = indexingService;
    }

    [HttpPost]
    public async Task<ActionResult> Index(int kcId, CancellationToken cancellationToken)
    {
        var result = await _indexingService.IndexAsync(kcId, User.InstructorId(), cancellationToken);
        return CreateResponse(result);
    }

    [HttpDelete]
    public async Task<ActionResult> Deindex(int kcId, CancellationToken cancellationToken)
    {
        var result = await _indexingService.DeindexAsync(kcId, User.InstructorId(), cancellationToken);
        return CreateResponse(result);
    }
}
