using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Instructors.Authoring
{
    [Route("api/authoring/courses/{courseId:int}/units")]
    [Authorize(Policy = "instructorPolicy")]
    public class UnitController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitService _unitService;

        public UnitController(IMapper mapper, IUnitService unitService)
        {
            _mapper = mapper;
            _unitService = unitService;
        }

        [HttpPost]
        public ActionResult<KnowledgeUnitDto> Create(int courseId, [FromBody] KnowledgeUnitDto unit)
        {
            var newUnit = _mapper.Map<KnowledgeUnit>(unit);
            newUnit.CourseId = courseId;

            var result = _unitService.Create(newUnit, User.InstructorId());
            if (result.IsFailed) return CreateErrorResponse(result.Errors);
            return Ok(_mapper.Map<KnowledgeUnitDto>(result.Value));
        }

        [HttpPut("{id:int}")]
        public ActionResult<KnowledgeUnitDto> Update(int courseId, [FromBody] KnowledgeUnitDto unit)
        {
            var updatedUnit = _mapper.Map<KnowledgeUnit>(unit);
            updatedUnit.CourseId = courseId;

            var result = _unitService.Update(updatedUnit, User.InstructorId());
            if (result.IsFailed) return CreateErrorResponse(result.Errors);
            return Ok(_mapper.Map<KnowledgeUnitDto>(result.Value));
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _unitService.Delete(id, User.InstructorId());
            if (result.IsFailed) return CreateErrorResponse(result.Errors);
            return Ok();
        }
    }
}
