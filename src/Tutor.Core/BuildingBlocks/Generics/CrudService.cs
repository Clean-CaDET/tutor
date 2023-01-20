using FluentResults;

namespace Tutor.Core.BuildingBlocks.Generics;

public class CrudService<T> where T : Entity
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly ICrudRepository<T> _crudRepository;

    public CrudService(ICrudRepository<T> crudRepository, IUnitOfWork unitOfWork)
    {
        _crudRepository = crudRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<PagedResult<T>> GetPaged(int page, int pageSize)
    {
        var result = _crudRepository.GetPaged(page, pageSize);
        return result;
    }

    public Result<T> Get(int id)
    {
        var result = _crudRepository.Get(id);
        if (result is null) return Result.Fail(FailureCode.NotFound);
        return result;
    }

    public virtual Result<T> Create(T entity)
    {
        var createdEntity = _crudRepository.Create(entity);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;
        
        return createdEntity;
    }

    public virtual Result<T> Update(T entity)
    {
        var updatedEntity = _crudRepository.Update(entity);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(updatedEntity);
    }

    public virtual Result Delete(int id)
    {
        _crudRepository.Delete(id);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}