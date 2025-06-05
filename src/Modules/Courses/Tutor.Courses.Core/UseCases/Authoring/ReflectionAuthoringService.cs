using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Courses.Core.Domain.Reflections;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Authoring;

public class ReflectionAuthoringService : CrudService<ReflectionDto, Reflection>, IReflectionAuthoringService
{
    private readonly IMapper _mapper;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IReflectionRepository _reflectionRepository;

    public ReflectionAuthoringService(IMapper mapper, IReflectionRepository reflectionRepository,
        IOwnedCourseRepository ownedCourseRepository, ICoursesUnitOfWork unitOfWork) : base(reflectionRepository, unitOfWork, mapper)
    {
        _mapper = mapper;
        _ownedCourseRepository = ownedCourseRepository;
        _reflectionRepository = reflectionRepository;
    }

    public Result<List<ReflectionDto>> GetByUnit(int unitId, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var result = _reflectionRepository.GetByUnit(unitId);
        return result.Select(_mapper.Map<ReflectionDto>).ToList();
    }

    public Result<ReflectionDto> Create(ReflectionDto reflection, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(reflection.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(reflection);
    }

    public Result<ReflectionDto> Update(ReflectionDto reflection, int instructorId)
    {
        var storedReflection = _reflectionRepository.GetWithQuestions(reflection.Id);
        if(storedReflection == null)
            return Result.Fail(FailureCode.NotFound);
        if (!_ownedCourseRepository.IsUnitOwner(storedReflection.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        storedReflection.Update(_mapper.Map<Reflection>(reflection));
        
        return Update(storedReflection);
    }

    public Result Delete(int id, int instructorId)
    {
        var reflection = CrudRepository.Get(id);
        if(reflection == null)
            return Result.Fail(FailureCode.NotFound);
        if (!_ownedCourseRepository.IsUnitOwner(reflection.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Delete(id);
    }

    public Result<List<ReflectionQuestionCategoryDto>> GetCategories()
    {
        var result = _reflectionRepository.GetCategories();
        return result.Select(_mapper.Map<ReflectionQuestionCategoryDto>).ToList();
    }
}