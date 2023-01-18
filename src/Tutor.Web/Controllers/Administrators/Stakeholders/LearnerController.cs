using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Management.Enrollments;
using Tutor.Core.UseCases.Management.Stakeholders;
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
    public ActionResult<PagedResult<StakeholderAccountDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string[] indexes)
    {
        Result<PagedResult<Learner>> result;
        if (indexes == null || indexes.Length == 0)
        {
            result = _learnerService.GetPaged(page, pageSize);
        }
        else
        {
            result = _learnerService.GetByIndexes(indexes);
        }

        if (result.IsFailed) return CreateErrorResponse(result.Errors);

        var items = result.Value.Results.Select(_mapper.Map<StakeholderAccountDto>).ToList();
        return Ok(new PagedResult<StakeholderAccountDto>(items, result.Value.TotalCount));
    }

    [HttpPost]
    public ActionResult<StakeholderAccountDto> Register([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Register(_mapper.Map<Learner>(stakeholderAccount), stakeholderAccount.Index, stakeholderAccount.Password);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<StakeholderAccountDto>(result.Value));
    }

    [HttpPost("bulk")]
    public ActionResult BulkRegister([FromBody] List<StakeholderAccountDto> stakeholderAccounts)
    {
        var result = _learnerService.BulkRegister(
            stakeholderAccounts.Select(a => _mapper.Map<Learner>(a)).ToList(),
            stakeholderAccounts.Select(a => a.Index).ToList(),
            stakeholderAccounts.Select(a => a.Password).ToList());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public ActionResult<StakeholderAccountDto> Update([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Update(_mapper.Map<Learner>(stakeholderAccount));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<StakeholderAccountDto>(result.Value));
    }

    [HttpPatch("{id:int}/archive")]
    public ActionResult<StakeholderAccountDto> Archive(int id, [FromBody] bool archive)
    {
        var result = _learnerService.Archive(id, archive);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<StakeholderAccountDto>(result.Value));
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _learnerService.Delete(id);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpGet("{id:int}/courses")]
    public ActionResult<CourseDto> GetEnrolledCourses(int id)
    {
        var result = _enrollmentService.GetEnrolledCourses(id);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        var items = result.Value.Select(_mapper.Map<CourseDto>).ToList();
        return Ok(new PagedResult<CourseDto>(items, items.Count));
    }
}