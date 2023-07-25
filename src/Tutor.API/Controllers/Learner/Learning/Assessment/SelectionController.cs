using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Learning.Assessment;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/knowledge-component/{kcId:int}/assessment-item/")]
public class SelectionController : BaseApiController
{
    private readonly ISelectionService _assessmentSelectionService;

    public SelectionController(ISelectionService assessmentSelectionService)
    {
        _assessmentSelectionService = assessmentSelectionService;
    }

    [HttpGet]
    public ActionResult<AssessmentItemDto> GetSuitableAssessmentItem(int kcId)
    {
        var result = _assessmentSelectionService.SelectSuitableAssessmentItem(kcId, User.LearnerId());
        return CreateResponse(result);
    }
}