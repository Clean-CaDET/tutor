using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.{{MODULE}}.API.Dtos;

namespace Tutor.{{MODULE}}.API.Public.{{USE_CASE}};

// CodeGen v1
public interface I{{NAME}}Service
{
    // TODO: Remove any unused endpoints to reduce maintenance cost and security risk.
    Result<PagedResult<{{NAME}}Dto>> GetPaged(int page, int pageSize);
    Result<{{NAME}}Dto> Create({{NAME}}Dto {{NAME_L}});
    Result<{{NAME}}Dto> Get(int id);
    Result<{{NAME}}Dto> Update({{NAME}}Dto {{NAME_L}});
    Result Delete(int id);
}