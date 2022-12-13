using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Knowledge;

public class CourseService : CrudService<Course>, ICourseService
{
    private readonly ICourseRepository _courseRepository;
    public CourseService (ICourseRepository courseRepository) : base (courseRepository)
    {
        _courseRepository = courseRepository;
    }
    public Result<PagedResult<Course>> GetAll(bool includeArchived, int page, int pageSize)
    {
        return includeArchived ? _courseRepository.GetPaged(page, pageSize) : _courseRepository.GetActive(page, pageSize);
    }
}