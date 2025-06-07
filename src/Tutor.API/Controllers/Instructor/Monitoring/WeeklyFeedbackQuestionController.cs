using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.Core.Domain;

namespace Tutor.API.Controllers.Instructor.Monitoring;

[Route("api/monitoring/feedback-questions")]
[Authorize(Policy = "monitoringFeedbackPolicy")]
public class WeeklyFeedbackQuestionController : BaseApiController
{
    private readonly ICrudRepository<WeeklyFeedbackQuestion> _questionRepository;

    public WeeklyFeedbackQuestionController(ICrudRepository<WeeklyFeedbackQuestion> questionRepository)
    {
        _questionRepository = questionRepository;
    }

    [HttpGet]
    public ActionResult<List<WeeklyFeedbackQuestion>> GetAll()
    {
        var results = _questionRepository.GetPaged(0, 0);
        return Ok(results.Results);
    }
}