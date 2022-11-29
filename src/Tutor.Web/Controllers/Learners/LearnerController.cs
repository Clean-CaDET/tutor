using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.Management.Stakeholder;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.CourseIteration;

namespace Tutor.Web.Controllers.Learners;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learner/")]
public class LearnerController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ILearnerService _learnerService;

    public LearnerController(IMapper mapper,
        ILearnerService learnerService)
    {
        _learnerService = learnerService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<LearnerDto> GetLearnerProfile()
    {
        var result = _learnerService.GetLearnerProfile(User.Id());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<LearnerDto>(result.Value));
    }
}