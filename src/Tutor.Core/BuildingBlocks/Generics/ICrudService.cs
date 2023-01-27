using FluentResults;

namespace Tutor.Core.BuildingBlocks.Generics;

public interface ICrudService<T> where T : Entity
{
    Result<PagedResult<T>> GetPaged(int page, int pageSize);
    Result<T> Get(int id);
    Result<T> Create(T entity);
    Result<T> Update(T entity);
    Result Delete(int id);
}