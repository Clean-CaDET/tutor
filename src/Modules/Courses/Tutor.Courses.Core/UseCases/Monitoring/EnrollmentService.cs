using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Enrollments;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.KnowledgeComponents.API.Internal;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class EnrollmentService : BaseService<EnrollmentDto, UnitEnrollment>, IEnrollmentService
{
    private readonly IUnitEnrollmentRepository _unitEnrollmentRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly ICrudRepository<KnowledgeUnit> _unitRepository;
    private readonly IMasteryFactory _masteryFactory;
    private readonly ICoursesUnitOfWork _unitOfWork;

    public EnrollmentService(IMapper mapper, IUnitEnrollmentRepository unitEnrollmentRepository, IOwnedCourseRepository ownedCourseRepository,
        ICoursesUnitOfWork unitOfWork, ICrudRepository<KnowledgeUnit> unitRepository, IMasteryFactory masteryFactory): base(mapper)
    {
        _unitEnrollmentRepository = unitEnrollmentRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _unitRepository = unitRepository;
        _masteryFactory = masteryFactory;
        _unitOfWork = unitOfWork;
    }

    public Result<List<EnrollmentDto>> GetEnrollments(EnrollmentFilterDto unitAndLearnerIds, int instructorId)
    {
        return MapToDto(_unitEnrollmentRepository
            .GetMany(unitAndLearnerIds.UnitIds, unitAndLearnerIds.LearnerIds));
    }

    public Result<List<EnrollmentDto>> BulkEnroll(int unitId, int[] learnerIds, EnrollmentDto newEnrollment, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var unit = _unitRepository.Get(unitId);
        if(unit == null)
            return Result.Fail(FailureCode.NotFound);

        var enrollments = Enroll(unit, newEnrollment, learnerIds);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;
        return MapToDto(enrollments);
    }

    private List<UnitEnrollment> Enroll(KnowledgeUnit unit, EnrollmentDto newEnrollment, int[] learnerIds)
    {
        var enrollments = _unitEnrollmentRepository.GetMany(unit.Id, learnerIds);
        enrollments.ForEach(e =>
        {
            e.Activate(newEnrollment.AvailableFrom, newEnrollment.BestBefore);
            _unitEnrollmentRepository.Update(e);
        });
        if (learnerIds.Length == enrollments.Count) return enrollments;

        var unenrolledLearners = learnerIds.Where(learnerId => enrollments.All(e => e.LearnerId != learnerId)).ToList();
        enrollments.AddRange(CreateNewEnrollments(unenrolledLearners, unit, newEnrollment));
        
        _masteryFactory.InitializeMasteries(unit.Id, unenrolledLearners.ToArray());

        return enrollments;
    }

    private List<UnitEnrollment> CreateNewEnrollments(List<int> learners, KnowledgeUnit unit, EnrollmentDto enrollment)
    {
        return learners.Select(learnerId =>
        {
            var newEnrollment = new UnitEnrollment(learnerId, enrollment.AvailableFrom, enrollment.BestBefore, unit);
            _unitEnrollmentRepository.Create(newEnrollment);

            return newEnrollment;
        }).ToList();
    }

    public Result<List<EnrollmentDto>> BulkUnenroll(int unitId, int[] learnerIds, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var enrollments = _unitEnrollmentRepository.GetMany(unitId, learnerIds);
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