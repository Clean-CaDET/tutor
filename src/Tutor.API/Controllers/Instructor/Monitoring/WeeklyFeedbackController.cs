using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/{courseId:int}/feedback")]
public class WeeklyFeedbackController : BaseApiController
{
    private readonly IWeeklyFeedbackService _feedbackService;

    public WeeklyFeedbackController(IWeeklyFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost("group")]
    public ActionResult<WeeklyFeedbackDto> GetForGroup(int courseId, [FromBody] GroupFeedbackRequestDto feedbackRequest)
    {
        return CreateResponse(_feedbackService.GetByGroup(courseId, feedbackRequest.LearnerIds, feedbackRequest.WeekEnd, User.InstructorId()));
    }

    [HttpGet]
    public ActionResult<List<WeeklyFeedbackDto>> GetForLearner(int courseId, [FromQuery] int learnerId)
    {
        return CreateResponse(_feedbackService.GetByCourseAndLearner(courseId, learnerId, User.InstructorId()));
    }

    [HttpPost]
    public ActionResult<WeeklyFeedbackDto> Create(int courseId, [FromBody] WeeklyFeedbackDto feedback)
    {
        feedback.CourseId = courseId;
        return CreateResponse(_feedbackService.Create(feedback, User.InstructorId()));
    }

    [HttpPut("{feedbackId:int}")]
    public ActionResult<WeeklyFeedbackDto> Update(int courseId, int feedbackId, [FromBody] WeeklyFeedbackDto feedback)
    {
        feedback.Id = feedbackId;
        feedback.CourseId = courseId;
        return CreateResponse(_feedbackService.Update(feedback, User.InstructorId()));
    }

    [HttpDelete("{feedbackId:int}")]
    public ActionResult<WeeklyFeedbackDto> Delete(int feedbackId)
    {
        return CreateResponse(_feedbackService.Delete(feedbackId, User.InstructorId()));
    }
}