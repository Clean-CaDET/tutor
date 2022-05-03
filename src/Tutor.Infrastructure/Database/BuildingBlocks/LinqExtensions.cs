using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Tutor.Infrastructure.Database.BuildingBlocks
{
    public static class LinqExtensions
    {
        /// <summary>
        /// LINQ extension that should be called last to get paged items.
        /// </summary>
        public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResult<T>(items, count);
        }
    }
}
