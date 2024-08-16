using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Authoring;
using Tutor.LearningTasks.API.Dtos.LearningTaskProgress;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/units")]
public class TaskGradingController : BaseApiController
{
    private readonly ILearningTaskService _taskService;
    private readonly IGradingService _gradingService;
    private readonly IUnitService _unitService;

    public TaskGradingController(ILearningTaskService taskService, IGradingService gradingService, IUnitService unitService)
    {
        _taskService = taskService;
        _gradingService = gradingService;
        _unitService = unitService;
    }

    [HttpGet]
    public ActionResult<List<KnowledgeUnitDto>> GetUnitsStartedDuringWeekBeforeDate([FromQuery(Name = "courseId")] int courseId,
        [FromQuery(Name = "learnerId")] int learnerId, [FromQuery(Name = "date")] DateTime date)
    {
        var result = _unitService.GetUnitsStartedDuringWeekBeforeDate(courseId, learnerId, DateTime.SpecifyKind(date, DateTimeKind.Utc), User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{unitId:int}/learning-tasks")]
    public ActionResult<List<LearningTaskDto>> GetTasksByUnit(int unitId)
    {
        var result = _taskService.GetByUnit(unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{unitId:int}/learning-tasks/learners/{learnerId:int}/progresses")]
    public ActionResult<List<TaskProgressDto>> GetByUnitAndLearner(int unitId, int learnerId)
    {
        var result = _gradingService.GetByUnitAndLearner(unitId, learnerId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{unitId:int}/learning-tasks/progresses/{progressId:int}/steps")]
    public ActionResult<TaskProgressDto> SubmitGrade(int unitId, int progressId, [FromBody] StepProgressDto stepProgress)
    {
        var result = _gradingService.SubmitGrade(unitId, progressId, stepProgress, User.InstructorId());
        return CreateResponse(result);
    }
}
