using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.DomainModel;
using Tutor.Web.Mappings.Domain.DTOs;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "coursePolicy")]
[Route("api/course/")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    [HttpGet("{courseId:int}")]
    public ActionResult<CourseDto> GetCourse(int courseId)
    {
        var result = _courseRepository.GetCourse(courseId);
        return Ok(_mapper.Map<CourseDto>(result));
    }
}