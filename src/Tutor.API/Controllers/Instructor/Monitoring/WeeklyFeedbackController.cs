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

    [HttpPost]
    public ActionResult<WeeklyFeedbackDto> GetForGroup(int courseId, [FromBody] GroupFeedbackRequestDto feedbackRequest)
    {
        return CreateResponse(_feedbackService.GetByGroup(courseId, feedbackRequest.LearnerIds, feedbackRequest.WeekEnd, User.InstructorId()));
    }

    [HttpGet("{learnerId:int}")]
    public ActionResult<List<WeeklyFeedbackDto>> GetForLearner(int courseId, int learnerId)
    {
        return CreateResponse(_feedbackService.GetByCourseAndLearner(courseId, learnerId, User.InstructorId()));
    }

    [HttpPost("{learnerId:int}")]
    public ActionResult<WeeklyFeedbackDto> Create(int courseId, int learnerId, [FromBody] WeeklyFeedbackDto feedback)
    {
        feedback.CourseId = courseId;
        feedback.LearnerId = learnerId;
        return CreateResponse(_feedbackService.Create(feedback, User.InstructorId()));
    }

    [HttpPut("{learnerId:int}/{feedbackId:int}")]
    public ActionResult<WeeklyFeedbackDto> Update(int courseId, int learnerId, int feedbackId, [FromBody] WeeklyFeedbackDto feedback)
    {
        feedback.Id = feedbackId;
        feedback.CourseId = courseId;
        feedback.LearnerId = learnerId;
        return CreateResponse(_feedbackService.Update(feedback, User.InstructorId()));
    }
}