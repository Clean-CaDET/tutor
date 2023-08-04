using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.{{MODULE}}.API.Dtos;
using Tutor.{{MODULE}}.API.Public.{{USE_CASE}};

namespace Tutor.API.Controllers.{{ROLE}}.{{USE_CASE}};

// CodeGen v1
[Authorize(Policy = "{{ROLE_L}}Policy")]
[Route("api/{{USE_CASE_L}}/{{NAME_L}}")]
public class {{NAME}}Controller : BaseApiController
{
    // TODO: Remove any unused endpoints to reduce maintenance cost and security risk.
    private readonly I{{NAME}}Service _{{NAME_L}}Service;

    public {{NAME}}Controller(I{{NAME}}Service {{NAME_L}}Service)
    {
        _{{NAME_L}}Service = {{NAME_L}}Service;
    }

    [HttpGet]
    public ActionResult<List<{{NAME}}Dto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _{{NAME_L}}Service.GetPaged(page, pageSize);
        return CreateResponse(result);
    }

    [HttpPost]
    public ActionResult<{{NAME}}Dto> Create([FromBody] {{NAME}}Dto {{NAME_L}})
    {
        var result = _{{NAME_L}}Service.Create({{NAME_L}});
        return CreateResponse(result);
    }

    [HttpGet("{id:int}")]
    public ActionResult<List<{{NAME}}Dto>> Get(int id)
    {
        var result = _{{NAME_L}}Service.Get(id);
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<{{NAME}}Dto> Update([FromBody] {{NAME}}Dto {{NAME_L}})
    {
        var result = _{{NAME_L}}Service.Update({{NAME_L}});
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _{{NAME_L}}Service.Delete(id);
        return CreateResponse(result);
    }
}