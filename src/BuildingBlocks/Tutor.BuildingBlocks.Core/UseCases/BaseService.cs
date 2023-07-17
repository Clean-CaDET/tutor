using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.BuildingBlocks.Core.UseCases;

/// <summary>
/// The base service class that offers methods for mapping TDomain objects to TDto object and vice-versa.
/// All services should inherit this service or its derived type.
/// </summary>
/// <typeparam name="TDto">Type of output data transfer object.</typeparam>
/// <typeparam name="TDomain">Type of domain object that maps to TDto</typeparam>
public abstract class BaseService<TDto, TDomain> where TDomain : Entity
{
    private readonly IMapper _mapper;

    protected BaseService(IMapper mapper)
    {
        _mapper = mapper;
    }

    protected TDomain MapToDomain(TDto dto)
    {
        return _mapper.Map<TDomain>(dto);
    }

    protected List<TDomain> MapToDomain(List<TDto> dtos)
    {
        return dtos.Select(dto => _mapper.Map<TDomain>(dto)).ToList();
    }

    protected Result<TDto> MapToDto(Result<TDomain> result)
    {
        if (result.IsFailed) return Result.Fail(result.Errors);
        return _mapper.Map<TDto>(result.Value);
    }

    protected Result<List<TDto>> MapToDto(Result<List<TDomain>> result)
    {
        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.Select(_mapper.Map<TDto>).ToList();
    }

    protected Result<PagedResult<TDto>> MapToDto(Result<PagedResult<TDomain>> result)
    {
        if (result.IsFailed) return Result.Fail(result.Errors);

        var items = result.Value.Results.Select(_mapper.Map<TDto>).ToList();
        return new PagedResult<TDto>(items, result.Value.TotalCount);
    }
}