using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Knowledge.RepositoryInterfaces;

public interface ICrudCourseRepository : ICrudRepository<Course>
{
    List<Course> GetActive();
}