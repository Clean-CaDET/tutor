using System.Collections.Generic;
using FluentResults;
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
    public Result<List<Course>> GetAll(bool includeArchived)
    {
        return includeArchived ? _courseRepository.GetAll() : _courseRepository.GetActive();
    }
}