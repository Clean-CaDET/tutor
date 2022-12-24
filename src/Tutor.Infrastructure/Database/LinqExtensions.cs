using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Infrastructure.Database;

public static class LinqExtensions
{
    /// <summary>
    /// LINQ extension that should be called last to get paged items.
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