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
[Route("api/grading/units")]
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
    public ActionResult<List<KnowledgeUnitDto>> GetUnitsForWeek([FromQuery] int courseId, [FromQuery] int learnerId, [FromQuery] DateTime weekEnd)
    {
        var result = _unitService.GetUnitsForWeek(courseId, learnerId, DateTime.SpecifyKind(weekEnd, DateTimeKind.Utc), User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{unitId:int}/tasks")]
    public ActionResult<List<LearningTaskDto>> GetTasksByUnit(int unitId)
    {
        var result = _taskService.GetByUnit(unitId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpGet("{unitId:int}/learners/{learnerId:int}/progress")]
    public ActionResult<List<TaskProgressDto>> GetByUnitAndLearner(int unitId, int learnerId)
    {
        var result = _gradingService.GetByUnitAndLearner(unitId, learnerId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPut("{unitId:int}/task-progress/{progressId:int}/steps")]
    public ActionResult<TaskProgressDto> SubmitGrade(int unitId, int progressId, [FromBody] StepProgressDto stepProgress)
    {
        var result = _gradingService.SubmitGrade(unitId, progressId, stepProgress, User.InstructorId());
        return CreateResponse(result);
    }
}
