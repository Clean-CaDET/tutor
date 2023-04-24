using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Enrollments;
using Tutor.Web.Mappings.Stakeholders;

namespace Tutor.Web.Controllers.Instructors.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring")]
public class GroupMonitoringController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IGroupMonitoringService _groupMonitoringService;

    public GroupMonitoringController(IMapper mapper, IGroupMonitoringService groupMonitoringService)
    {
        _mapper = mapper;
        _groupMonitoringService = groupMonitoringService;
    }

    [HttpGet("{courseId:int}/groups")]
    public ActionResult<List<GroupDto>> GetCourseGroups(int courseId)
    {
        var result = _groupMonitoringService.GetCourseGroups(User.InstructorId(), courseId);
        return CreateResponse<LearnerGroup, GroupDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpGet("{courseId:int}/groups/{groupId:int}")]
    public ActionResult<PagedResult<StakeholderAccountDto>> GetGroupLearners(int courseId, int groupId, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _groupMonitoringService.GetLearners(User.InstructorId(), courseId, groupId, page, pageSize);
        return CreateResponse<Learner, StakeholderAccountDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpPost("progress/{unitId:int}")]
    public ActionResult<List<KcmProgressDto>> GetLearnerProgress(int unitId, [FromBody] int[] learnerIds)
    {
        var result = _groupMonitoringService.GetLearnerProgress(unitId, learnerIds, User.InstructorId());
        return CreateResponse<KnowledgeComponentMastery, KcmProgressDto>(result, Ok, CreateErrorResponse, _mapper);
    }
}