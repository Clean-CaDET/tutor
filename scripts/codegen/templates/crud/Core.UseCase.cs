using AutoMapper;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.{{MODULE}}.API.Dtos;
using Tutor.{{MODULE}}.API.Public.{{USE_CASE}};
using Tutor.{{MODULE}}.Core.Domain;

namespace Tutor.{{MODULE}}.Core.UseCases.{{USE_CASE}};

// CodeGen v1
public class {{NAME}}Service : CrudService<{{NAME}}Dto, {{NAME}}>, I{{NAME}}Service
{
    public {{NAME}}Service(ICrudRepository<{{NAME}}> repository, I{{MODULE}}UnitOfWork unitOfWork, IMapper mapper) 
        : base(repository, unitOfWork, mapper) {}

    // TODO: Examine if you need additional access control checks (ownership for instructor, enrollment for learner).
    // TODO: The current service offers basic CRUD functionality without any restrictions
}

// TODO: Expand the {{Module}}Startup class to setup dependency injection for the new service and repository