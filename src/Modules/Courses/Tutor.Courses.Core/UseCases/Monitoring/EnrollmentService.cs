using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Monitoring;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class EnrollmentService : BaseService<UnitEnrollmentDto, UnitEnrollment>, IEnrollmentService
{
    private readonly IUnitEnrollmentRepository _unitEnrollmentRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly ICrudRepository<KnowledgeUnit> _unitRepository;
    private readonly ILearnerMasteryService _learnerMasteryService;
    private readonly ICoursesUnitOfWork _unitOfWork;

    public EnrollmentService(IMapper mapper, IUnitEnrollmentRepository unitEnrollmentRepository, IOwnedCourseRepository ownedCourseRepository,
        ICoursesUnitOfWork unitOfWork, ICrudRepository<KnowledgeUnit> unitRepository, ILearnerMasteryService learnerMasteryService): base(mapper)
    {
        _unitEnrollmentRepository = unitEnrollmentRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _unitRepository = unitRepository;
        _learnerMasteryService = learnerMasteryService;
        _unitOfWork = unitOfWork;
    }

    public Result<List<UnitEnrollmentDto>> GetEnrollments(int unitId, int[] learnerIds, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        return MapToDto(_unitEnrollmentRepository.GetEnrollments(unitId, learnerIds));
    }

    public Result<List<UnitEnrollmentDto>> BulkEnroll(int unitId, int[] learnerIds, DateTime start, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var unit = _unitRepository.Get(unitId);
        if(unit == null)
            return Result.Fail(FailureCode.NotFound);

        var enrollments = Enroll(unit, start, learnerIds);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;
        return MapToDto(enrollments);
    }

    public Result<UnitEnrollmentDto> Enroll(int unitId, int learnerId, DateTime start, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var unit = _unitRepository.Get(unitId);
        if (unit == null)
            return Result.Fail(FailureCode.NotFound);

        var enrollment = Enroll(unit, start, new[] { learnerId })[0];

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        _learnerMasteryService.InitializeMasteries(unit.Id, learnerId);

        return MapToDto(enrollment);
    }

    private List<UnitEnrollment> Enroll(KnowledgeUnit unit, DateTime start, int[] learnerIds)
    {
        var enrollments = _unitEnrollmentRepository.GetEnrollments(unit.Id, learnerIds);
        enrollments.ForEach(e =>
        {
            e.Activate(start);
            _unitEnrollmentRepository.Update(e);
        });
        if (learnerIds.Length == enrollments.Count) return enrollments;

        var unenrolledLearners = learnerIds.Where(learnerId => enrollments.All(e => e.LearnerId != learnerId)).ToList();
        enrollments.AddRange(unenrolledLearners.Select(learnerId => CreateNewEnrollment(unit, start, learnerId)).ToList());
        _learnerMasteryService.InitializeMasteries(unit.Id, learnerIds);

        return enrollments;
    }

    private UnitEnrollment CreateNewEnrollment(KnowledgeUnit unit, DateTime start, int learnerId)
    {
        var newEnrollment = new UnitEnrollment(learnerId, start, unit);
        _unitEnrollmentRepository.Create(newEnrollment);

        return newEnrollment;
    }

    public Result Unenroll(int unitId, int learnerId, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var enrollment = _unitEnrollmentRepository.GetEnrollment(unitId, learnerId);
        if (enrollment == null) return Result.Fail(FailureCode.NotFound);

        enrollment.Status = EnrollmentStatus.Deactivated;
        _unitEnrollmentRepository.Update(enrollment);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }

    public Result<List<UnitEnrollmentDto>> BulkUnenroll(int unitId, int[] learnerIds, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var enrollments = _unitEnrollmentRepository.GetEnrollments(unitId, learnerIds);
        enrollments.ForEach(e =>
        {
            e.Status = EnrollmentStatus.Deactivated;
            _unitEnrollmentRepository.Update(e);
        });

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(enrollments);
    }
}