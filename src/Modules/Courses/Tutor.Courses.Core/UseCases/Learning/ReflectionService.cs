using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Internal;
using Tutor.Courses.API.Public.Learning;
using Tutor.Courses.Core.Domain.Reflections;

namespace Tutor.Courses.Core.UseCases.Learning;

public class ReflectionService : BaseService<ReflectionDto, Reflection>, IReflectionService
{
    private readonly IMapper _mapper;
    private readonly IReflectionRepository _reflectionRepository;
    private readonly IEnrollmentValidator _enrollmentValidator;
    private readonly ICoursesUnitOfWork _uow;

    public ReflectionService(IMapper mapper, IReflectionRepository reflectionRepository,
        IEnrollmentValidator enrollmentValidator, ICoursesUnitOfWork uow) : base(mapper)
    {
        _mapper = mapper;
        _reflectionRepository = reflectionRepository;
        _enrollmentValidator = enrollmentValidator;
        _uow = uow;
    }

    public Result<List<ReflectionDto>> GetAll(int unitId, int learnerId)
    {
        if (!_enrollmentValidator.HasAccessibleEnrollment(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        var reflections = _reflectionRepository.GetByUnitWithSubmission(unitId, learnerId);
        return MapToDto(reflections);
    }

    public Result<ReflectionDto> GetWithSubmission(int reflectionId, int learnerId)
    {
        var reflection = _reflectionRepository.GetWithSubmission(reflectionId, learnerId);
        if(reflection == null)
            return Result.Fail(FailureCode.NotFound);
        if (!_enrollmentValidator.HasAccessibleEnrollment(reflection.UnitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        return MapToDto(reflection);
    }

    public Result SubmitAnswer(int reflectionId, int learnerId, ReflectionAnswerDto answer)
    {
        var reflection = _reflectionRepository.GetWithSubmission(reflectionId, learnerId);
        if (reflection == null)
            return Result.Fail(FailureCode.NotFound);
        if (!_enrollmentValidator.HasAccessibleEnrollment(reflection.UnitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        answer.ReflectionId = reflectionId;
        answer.LearnerId = learnerId;
        if (reflection.Submissions.Count > 0)
        {
            reflection.Submissions[0].Update(_mapper.Map<ReflectionAnswer>(answer));
            _reflectionRepository.CreateAnswer(reflection.Submissions[0]);
        }
        else
        {
            _reflectionRepository.CreateAnswer(_mapper.Map<ReflectionAnswer>(answer));
        }

        return _uow.Save();
    }
}