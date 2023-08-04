using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.{{MODULE}}.API.Dtos;
using Tutor.{{MODULE}}.API.Public.{{USE_CASE}};
using Tutor.{{MODULE}}.Core.Domain;

namespace Tutor.{{MODULE}}.Core.UseCases.{{USE_CASE}};

// CodeGen v1
// TODO: If this service is not primarily focused on returning one entity, you can remove the BaseService inheritance.
// TODO: In that case, add a field: private readonly IMapper _mapper;
public class {{NAME}}Service : BaseService<{{NAME}}Dto, {{NAME}}>, I{{NAME}}Service
{
    private readonly I{{NAME}}Repository _repository;
    private readonly I{{MODULE}}UnitOfWork _unitOfWork;

    public {{NAME}}Service(I{{NAME}}Repository repository, I{{MODULE}}UnitOfWork unitOfWork, IMapper mapper) : base(mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    // TODO: Remove unneeded methods
    public Result<{{NAME}}Dto> Get(int id)
    {
        var result = _repository.Get(id);
        if(result == null)
            return Result.Fail(FailureCode.NotFound);

        return MapToDto(result);
    }
}

// TODO: Expand the {{MODULE}}.Infrastructure.{{Module}}Startup class to setup dependency injection for the new service and repository