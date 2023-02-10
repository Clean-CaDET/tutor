using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.UseCases.Management.Courses;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Administrators.Courses;

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
    public ActionResult<List<CourseDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _courseService.GetAll(page, pageSize);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);

        var items = result.Value.Results.Select(_mapper.Map<CourseDto>).ToList();
        return Ok(new PagedResult<CourseDto>(items, result.Value.TotalCount));
    }

    [HttpPost]
    public ActionResult<CourseDto> Create([FromBody] CourseDto course)
    {
        var result = _courseService.CreateWithGroup(_mapper.Map<Course>(course));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<CourseDto>(result.Value));
    }

    [HttpPost("{id:int}/clone")]
    public ActionResult<CourseDto> Clone(int id, [FromBody] CourseDto course)
    {
        var result = _courseService.Clone(id, _mapper.Map<Course>(course));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<CourseDto>(result.Value));
    }

    [HttpPut("{id:int}")]
    public ActionResult<CourseDto> Update([FromBody] CourseDto course)
    {
        var result = _courseService.Update(_mapper.Map<Course>(course));
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<CourseDto>(result.Value));
    }

    [HttpPatch("{id:int}/archive")]
    public ActionResult<CourseDto> Archive(int id, [FromBody] bool archive)
    {
        var result = _courseService.Archive(id, archive);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(_mapper.Map<CourseDto>(result.Value));
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _courseService.Delete(id);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}