using AutoMapper;
using FluentResults;
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
    private readonly ILearnerService _learnerService;
    private readonly IEnrollmentService _enrollmentService;

    public LearnerController(IMapper mapper, ILearnerService learnerService, IEnrollmentService enrollmentService) : base(mapper)
    {
        _learnerService = learnerService;
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var (learners, roles) = _learnerService.GetPagedWithRole(page, pageSize).Value;
        var learnerDtos = learners.Results.Select(_mapper.Map<StakeholderAccountDto>).ToList();
        var learnerRoles = learnerDtos.Zip(roles, (learner, role) => { learner.LearnerType = role.ToString(); return learner; }).ToList();

        return Ok(new PagedResult<StakeholderAccountDto>(learnerRoles, learners.TotalCount));
    }

    // Post because of potential URL length limit violation with query params
    [HttpPost("selected")]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetSelected([FromBody] string[] indexes)
    {
        var result = _learnerService.GetByIndexes(indexes);
        return CreateResponse<Learner, StakeholderAccountDto>(result);
    }

    [HttpPost]
    public ActionResult<StakeholderAccountDto> Register([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = MapLearner(stakeholderAccount);
        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }
        var learner = result.Value;

        result = _learnerService.Register(learner, stakeholderAccount.Index, stakeholderAccount.Password, 
            learner.LearnerType == LearnerType.Regular ? UserRole.Learner : UserRole.LearnerCommercial);
        return CreateResponse<Learner, StakeholderAccountDto>(result);
    }

    [HttpPost("bulk")]
    public ActionResult<BulkAccountsDto> BulkRegister([FromBody] List<StakeholderAccountDto> stakeholderAccounts)
    {
        var mappingResult = MapLearners(stakeholderAccounts);
        if (mappingResult.IsFailed)
        {
            return BadRequest(mappingResult.Errors);
        }
        var learners = mappingResult.Value;

        var result = _learnerService.BulkRegister(
            learners,
            stakeholderAccounts.Select(a => a.Index).ToList(),
            stakeholderAccounts.Select(a => a.Password).ToList(),
            learners.First().LearnerType == LearnerType.Regular ? UserRole.Learner : UserRole.LearnerCommercial);
        return CreateResponse<List<Learner>, List<StakeholderAccountDto>>(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<StakeholderAccountDto> Update([FromBody] StakeholderAccountDto stakeholderAccount)
    {
        var result = _learnerService.Update(_mapper.Map<Learner>(stakeholderAccount));
        return CreateResponse<Learner, StakeholderAccountDto>(result);
    }

    [HttpPatch("{id:int}/archive")]
    public ActionResult<StakeholderAccountDto> Archive(int id, [FromBody] bool archive)
    {
        var result = _learnerService.Archive(id, archive);
        return CreateResponse<Learner, StakeholderAccountDto>(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _learnerService.Delete(id);
        return CreateResponse(result);
    }

    [HttpGet("{id:int}/courses")]
    public ActionResult<PagedResult<CourseDto>> GetEnrolledCourses(int id, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _enrollmentService.GetEnrolledCourses(id, page, pageSize);
        return CreateResponse<Course, CourseDto>(result);
    }

    private Result<Learner> MapLearner(StakeholderAccountDto stakeholderAccount)
    {
        Learner learner;
        try
        {
            learner = _mapper.Map<Learner>(stakeholderAccount);
        }
        catch (AutoMapperMappingException e)
        {
            Error rootError = new Error(e.Message).CausedBy(e);
            return Result.Fail("Unsupported learner type.").WithError(rootError);
        }
        return Result.Ok(learner);
    }

    private Result<List<Learner>> MapLearners(List<StakeholderAccountDto> stakeholderAccounts)
    {
        if (stakeholderAccounts.Select(s => s.LearnerType).Distinct().Count() > 1)
        {
            return Result.Fail("All learners must be of same type.");
        }
        var result = stakeholderAccounts.Select(MapLearner).ToList();
        var failed = result.FirstOrDefault(p => p.IsFailed);
        if (failed != null)
        {
            return Result.Fail(failed.Errors);
        }
        var learners = result.Select(l => l.Value).ToList();
        return learners;
    }
}