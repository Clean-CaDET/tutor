using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class EnrollmentService : BaseService<UnitEnrollmentDto, UnitEnrollment>, IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly ICrudRepository<KnowledgeUnit> _unitRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;

    public EnrollmentService(IMapper mapper, IEnrollmentRepository enrollmentRepository, IOwnedCourseRepository ownedCourseRepository,
        ICoursesUnitOfWork unitOfWork, ICrudRepository<KnowledgeUnit> unitRepository): base(mapper)
    {
        _enrollmentRepository = enrollmentRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _unitRepository = unitRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<List<UnitEnrollmentDto>> GetEnrollments(int unitId, int[] learnerIds, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        return MapToDto(_enrollmentRepository.GetEnrollments(unitId, learnerIds));
    }

    public Result<List<UnitEnrollmentDto>> BulkEnroll(int unitId, int[] learnerIds, DateTime start, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        
        var unit = _unitRepository.Get(unitId);
        if(unit == null) return Result.Fail(FailureCode.NotFound);

        var enrollments = learnerIds.Select(learnerId => Enroll(unit, start, learnerId)).ToList();

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(enrollments);
    }

    public Result<UnitEnrollmentDto> Enroll(int unitId, int learnerId, DateTime start, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var unit = _unitRepository.Get(unitId);
        if (unit == null) return Result.Fail(FailureCode.NotFound);


        var enrollment = Enroll(unit, start, learnerId);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(enrollment);
    }

    private UnitEnrollment Enroll(KnowledgeUnit unit, DateTime start, int learnerId)
    {
        var existingEnrollment = _enrollmentRepository.GetEnrollment(unit.Id, learnerId);
        if(existingEnrollment != null)
        {
            if (existingEnrollment.Status == EnrollmentStatus.Active) return existingEnrollment;
            
            existingEnrollment.Status = EnrollmentStatus.Active;
            existingEnrollment.Start = start;
            return _enrollmentRepository.Update(existingEnrollment);
        }

        var newEnrollment = new UnitEnrollment(learnerId, start, unit);
        _enrollmentRepository.Create(newEnrollment);

        //CreateMasteries(unit, learnerId);

        return newEnrollment;
    }

    /*private void CreateMasteries(KnowledgeUnit unit, int learnerId)
    {
        foreach (var kc in unit.KnowledgeComponents)
        {
            var assessmentMasteries = kc.AssessmentItems
                .OrderBy(i => i.Order)
                .Select(item => new AssessmentItemMastery(item.Id)).ToList();
            var kcMastery = new KnowledgeComponentMastery(learnerId, kc.Id, assessmentMasteries);
            _knowledgeMasteryRepository.Create(kcMastery);
        }
    }*/ // TODO: Move to KC modules

    public Result Unenroll(int unitId, int learnerId, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var enrollment = _enrollmentRepository.GetEnrollment(unitId, learnerId);
        if (enrollment == null) return Result.Fail(FailureCode.NotFound);

        enrollment.Status = EnrollmentStatus.Deactivated;
        _enrollmentRepository.Update(enrollment);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }

    public Result<List<UnitEnrollmentDto>> BulkUnenroll(int unitId, int[] learnerIds, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var enrollments = _enrollmentRepository.GetEnrollments(unitId, learnerIds);
        enrollments.ForEach(e =>
        {
            e.Status = EnrollmentStatus.Deactivated;
            _enrollmentRepository.Update(e);
        });

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(enrollments);
    }
}