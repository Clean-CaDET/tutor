using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.Domain;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.BuildingBlocks.Infrastructure.Database;

public static class LinqExtensions
{
    /// <summary>
    /// LINQ extension that should be called last to get paged items. Includes ordering by Id.
    /// </summary>
    public static async Task<PagedResult<T>> GetPagedById<T>(this IQueryable<T> source, int pageIndex, int pageSize) where T : Entity
    {
        var count = await source.CountAsync();

        if (pageSize != 0 && pageIndex != 0)
        {
            source = source.OrderByDescending(e => e.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        var items = await source.ToListAsync();
        return new PagedResult<T>(items, count);
    }

    /// <summary>
    /// LINQ extension that should be called last to get paged items. Does not include any ordering.
    /// </summary>
    public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();

        if (pageSize != 0 && pageIndex != 0)
        {
            source = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        var items = await source.ToListAsync();
        return new PagedResult<T>(items, count);
    }
}