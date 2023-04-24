using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Mappings.Knowledge.DTOs;

namespace Tutor.Web.Controllers.Instructors.Authoring;

[Route("api/authoring/knowledge-components")]
[Authorize(Policy = "instructorPolicy")]
public class KnowledgeComponentController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IKnowledgeComponentService _kcService;

    public KnowledgeComponentController(IMapper mapper, IKnowledgeComponentService kcService)
    {
        _mapper = mapper;
        _kcService = kcService;
    }

    [HttpGet("{id:int}")]
    public ActionResult<KnowledgeComponentDto> Get(int id)
    {
        var result = _kcService.Get(id, User.InstructorId());
        return CreateResponse<KnowledgeComponent, KnowledgeComponentDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpPost]
    public ActionResult<KnowledgeComponentDto> Create([FromBody] KnowledgeComponentDto kc)
    {
        var newKc = _mapper.Map<KnowledgeComponent>(kc);

        var result = _kcService.Create(newKc, User.InstructorId());
        return CreateResponse<KnowledgeComponent, KnowledgeComponentDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpPut("{id:int}")]
    public ActionResult<KnowledgeComponentDto> Update([FromBody] KnowledgeComponentDto kc)
    {
        var updatedKc = _mapper.Map<KnowledgeComponent>(kc);

        var result = _kcService.Update(updatedKc, User.InstructorId());
        return CreateResponse<KnowledgeComponent, KnowledgeComponentDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _kcService.Delete(id, User.InstructorId());
        return CreateResponse(result, Ok, CreateErrorResponse);
    }
}