using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.DomainModel;
using Tutor.Web.Controllers.Domain.DTOs;

namespace Tutor.Web.Controllers.Domain;

[Authorize(Policy = "instructorPolicy")]
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
    public ActionResult<List<CourseDto>> GetCourse(int courseId)
    {
        var result = _courseRepository.GetCourse(courseId);
        return Ok(_mapper.Map<CourseDto>(result));
    }
}