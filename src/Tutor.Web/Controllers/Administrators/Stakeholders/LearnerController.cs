using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Administrators.Stakeholders;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/learners")]
public class LearnerController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ILearnerService _learnerService;
    private readonly IEnrollmentService _enrollmentService;

    public LearnerController(IMapper mapper, ILearnerService learnerService, IEnrollmentService enrollmentService)
    {
        _mapper = mapper;
        _learnerService = learnerService;
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _learnerService.GetPaged(page, pageSize);
        return CreateResponse<Learner, StakeholderAccountDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    // Post because of potential URL length limit violation with query params
    [HttpPost("selected")]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetSelected([FromBody] string[] indexes)
    {
        var result = _learnerService.GetByIndexes(indexes);
        return CreateResponse<Learner, StakeholderAccountDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpPost]
    public ActionResult<StakeholderAccountDto> Register([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Register(_mapper.Map<Learner>(stakeholderAccount), stakeholderAccount.Index, stakeholderAccount.Password, UserRole.Learner);
        return CreateResponse<Learner, StakeholderAccountDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpPost("bulk")]
    public ActionResult BulkRegister([FromBody] List<StakeholderAccountDto> stakeholderAccounts)
    {
        var result = _learnerService.BulkRegister(
            stakeholderAccounts.Select(a => _mapper.Map<Learner>(a)).ToList(),
            stakeholderAccounts.Select(a => a.Index).ToList(),
            stakeholderAccounts.Select(a => a.Password).ToList());
        return CreateResponse(result, Ok, CreateErrorResponse);
    }

    [HttpPut("{id:int}")]
    public ActionResult<StakeholderAccountDto> Update([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Update(_mapper.Map<Learner>(stakeholderAccount));
        return CreateResponse<Learner, StakeholderAccountDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpPatch("{id:int}/archive")]
    public ActionResult<StakeholderAccountDto> Archive(int id, [FromBody] bool archive)
    {
        var result = _learnerService.Archive(id, archive);
        return CreateResponse<Learner, StakeholderAccountDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _learnerService.Delete(id);
        return CreateResponse(result, Ok, CreateErrorResponse);
    }

    [HttpGet("{id:int}/courses")]
    public ActionResult<CourseDto> GetEnrolledCourses(int id)
    {
        var result = _enrollmentService.GetEnrolledCourses(id);
        // Not using generic method because service returns list, not paged
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        var items = result.Value.Select(_mapper.Map<CourseDto>).ToList();
        return Ok(new PagedResult<CourseDto>(items, items.Count));
    }
}