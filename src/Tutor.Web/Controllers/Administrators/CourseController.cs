using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Administrators;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses")]
public class CourseController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ICourseService _courseService;
    
    public CourseController(IMapper mapper, ICourseService courseService)
    {
        _mapper = mapper;
        _courseService = courseService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetAll()
    {
        var result = _courseService.GetAll(true);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value.Select(_mapper.Map<CourseDto>).ToList());
    }

    [HttpPost]
    public ActionResult<CourseDto> Create([FromBody] CourseDto course)
    {
        var result = _courseService.Create(_mapper.Map<Course>(course));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<CourseDto>(result.Value));
    }

    [HttpPut("{courseId:int}")]
    public ActionResult Update([FromBody] CourseDto course)
    {
        var result = _courseService.Update(_mapper.Map<Course>(course));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }

    [HttpDelete("{courseId:int}")]
    public ActionResult Delete(int courseId)
    {
        var result = _courseService.Delete(courseId);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}