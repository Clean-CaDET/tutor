using FluentResults;

namespace Tutor.Core.BuildingBlocks.Generics;

public class CrudService<T> where T : Entity
{
    protected readonly ICrudRepository<T> _crudRepository;
    public CrudService(ICrudRepository<T> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public Result<PagedResult<T>> GetPaged(int page, int pageSize)
    {
        var result = _crudRepository.GetPaged(page, pageSize);
        return result;
    }

    public Result<T> Get(int id)
    {
        var result = _crudRepository.Get(id);
        return result;
    }

    public virtual Result<T> Create(T entity)
    {
        var createdEntity = _crudRepository.Create(entity);
        return createdEntity;
    }

    public Result<T> Update(T entity)
    {
        var updatedEntity = _crudRepository.Update(entity);
        return Result.Ok(updatedEntity);
    }

    public virtual Result Delete(int id)
    {
        _crudRepository.Delete(id);
        return Result.Ok();
    }
}