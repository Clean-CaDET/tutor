using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Knowledge.RepositoryInterfaces;

public interface ICourseRepository : ICrudRepository<Course>
{
    PagedResult<Course> GetActive(int page, int pageSize);
}