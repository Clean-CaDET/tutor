using System.Collections.Generic;
using FluentResults;

namespace Tutor.Core.BuildingBlocks.Generics;

public class CrudService<T> where T : Entity
{
    private readonly ICrudRepository<T> _crudRepository;
    public CrudService(ICrudRepository<T> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public Result<List<T>> GetAll()
    {
        var result = _crudRepository.GetAll();
        return Result.Ok(result);
    }

    public Result<T> Get(int id)
    {
        var result = _crudRepository.Get(id);
        return Result.Ok(result);
    }

    public Result<T> Create(T entity)
    {
        var createdEntity = _crudRepository.Create(entity);
        return Result.Ok(createdEntity);
    }

    public Result Update(T entity)
    {
        _crudRepository.Update(entity);
        return Result.Ok();
    }

    public Result Delete(int id)
    {
        _crudRepository.Delete(id);
        return Result.Ok();
    }
}