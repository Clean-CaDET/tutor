using FluentResults;

namespace Tutor.Core.BuildingBlocks.Generics;

public class CrudService<T> where T : Entity
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly ICrudRepository<T> CrudRepository;

    public CrudService(ICrudRepository<T> crudRepository, IUnitOfWork unitOfWork)
    {
        CrudRepository = crudRepository;
        UnitOfWork = unitOfWork;
    }

    public Result<PagedResult<T>> GetPaged(int page, int pageSize)
    {
        var result = CrudRepository.GetPaged(page, pageSize);
        return result;
    }

    public Result<T> Get(int id)
    {
        var result = CrudRepository.Get(id);
        if (result is null) return Result.Fail(FailureCode.NotFound);
        return result;
    }

    public virtual Result<T> Create(T entity)
    {
        var createdEntity = CrudRepository.Create(entity);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;
        
        return createdEntity;
    }

    public virtual Result<T> Update(T entity)
    {
        var updatedEntity = CrudRepository.Update(entity);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(updatedEntity);
    }

    public virtual Result Delete(int id)
    {
        var entity = CrudRepository.Get(id);
        if (entity is null) return Result.Fail(FailureCode.NotFound);

        CrudRepository.Delete(entity);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}