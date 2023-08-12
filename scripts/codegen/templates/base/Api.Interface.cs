using FluentResults;
using Tutor.{{MODULE}}.API.Dtos;

namespace Tutor.{{MODULE}}.API.Public.{{USE_CASE}};

// CodeGen v1
public interface I{{NAME}}Service
{
    // TODO: Remove any unused endpoints to reduce maintenance cost and security risk.
    Result<{{NAME}}Dto> Get(int id);
}