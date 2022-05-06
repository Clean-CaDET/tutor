using System.Collections.Generic;

namespace Tutor.Core.BuildingBlocks
{
    public class PagedResult<T>
    {
        public List<T> Results { get; private set; }
        public int TotalCount { get; private set; }

        public PagedResult(List<T> items, int totalCount)
        {
            TotalCount = totalCount;
            Results = items;
        }
    }
}
