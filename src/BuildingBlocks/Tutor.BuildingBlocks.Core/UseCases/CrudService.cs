using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.BuildingBlocks.Core.UseCases;

/// <summary>
/// A base service class that offers CRUD methods for persisting TDomain objects, based on the passed TDto object.
/// </summary>
/// <typeparam name="TDto">Type of output data transfer object.</typeparam>
/// <typeparam name="TDomain">Type of domain object that maps to TDto</typeparam>
public abstract class CrudService<TDto, TDomain> : BaseService<TDto, TDomain> where TDomain : Entity
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly ICrudRepository<TDomain> CrudRepository;

    protected CrudService(ICrudRepository<TDomain> crudRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
    {
        CrudRepository = crudRepository;
        UnitOfWork = unitOfWork;
    }

    public Result<PagedResult<TDto>> GetPaged(int page, int pageSize)
    {
        var result = CrudRepository.GetPaged(page, pageSize);
        return MapToDto(result);
    }

    public Result<TDto> Get(int id)
    {
        var result = CrudRepository.Get(id);
        return result == null ? Result.Fail(FailureCode.NotFound) : MapToDto(result);
    }

    public virtual Result<TDto> Create(TDto entity)
    {
        var createdEntity = CrudRepository.Create(MapToDomain(entity));

        var result = UnitOfWork.Save();
        return result.IsFailed ? result : MapToDto(createdEntity);
    }

    public virtual Result<TDto> Update(TDto entity)
    {
        var updatedEntity = CrudRepository.Update(MapToDomain(entity));

        var result = UnitOfWork.Save();
        return result.IsFailed ? result : MapToDto(updatedEntity);
    }

    /// <summary>
    /// Updates an existing domain entity directly. This method is intended for cases where an existing domain entity 
    /// has been retrieved and requires direct modification, particularly for aggregates with associated entities.
    /// After applying changes to the provided domain entity, it saves the updated entity and its associated entities to the database.
    /// </summary>
    public virtual Result<TDto> Update(TDomain entity)
    {
        try
        {
            CrudRepository.UpdateWithAssociatedEntites(entity);
        } 
        catch (Exception)
        {
            return Result.Fail(FailureCode.Conflict);
        }
        var result = UnitOfWork.Save();
        return result.IsFailed ? result : MapToDto(entity);
    }

    public virtual Result Delete(int id)
    {
        var entity = CrudRepository.Get(id);
        if (entity is null) return Result.Fail(FailureCode.NotFound);

        CrudRepository.Delete(entity);

        var result = UnitOfWork.Save();
        return result.IsFailed ? result : Result.Ok();
    }
}