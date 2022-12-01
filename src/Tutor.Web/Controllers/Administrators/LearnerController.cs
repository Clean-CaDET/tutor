using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Stakeholder;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/learners")]
public class LearnerController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ILearnerService _learnerService;

    public LearnerController(IMapper mapper, ILearnerService learnerService)
    {
        _mapper = mapper;
        _learnerService = learnerService;
    }

    [HttpGet]
    public ActionResult<List<LearnerDto>> GetAll()
    {
        var result = _learnerService.GetAll();
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<LearnerDto>).ToList());
    }

    [HttpPost]
    public ActionResult<LearnerDto> Create([FromBody] LearnerDto learner)
    {
        var result = _learnerService.Create(_mapper.Map<Learner>(learner));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<LearnerDto>(result.Value));
    }

    [HttpPut("{learnerId:int}")]
    public ActionResult Update([FromBody] LearnerDto learner)
    {
        var result = _learnerService.Update(_mapper.Map<Learner>(learner));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpDelete("{learnerId:int}")]
    public ActionResult Delete(int learnerId)
    {
        var result = _learnerService.Delete(learnerId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}