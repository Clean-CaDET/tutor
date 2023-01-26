using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Monitoring;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository, IOwnedCourseRepository ownedCourseRepository)
    {
        _enrollmentRepository = enrollmentRepository;
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<List<Course>> GetEnrolledCourses(int learnerId)
    {
        return _enrollmentRepository.GetEnrolledCourses(learnerId);
    }

    public Result<Course> GetCourseWithEnrolledAndActiveUnits(int courseId, int learnerId)
    {
        return _enrollmentRepository.GetCourseEnrolledAndActiveUnits(courseId, learnerId);
    }

    public Result<List<UnitEnrollment>> GetEnrollments(int unitId, int[] learnerIds, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        return _enrollmentRepository.GetEnrollments(unitId, learnerIds);
    }

    public Result<List<UnitEnrollment>> BulkEnroll(int unitId, int[] learnerIds, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var enrollments = new List<UnitEnrollment>();
        foreach (var learnerId in learnerIds)
        {
            //UoW violation
            enrollments.Add(Enroll(unitId, learnerId));
        }

        return enrollments;
    }

    public Result<UnitEnrollment> Enroll(int unitId, int learnerId, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        return Enroll(unitId, learnerId);
    }

    private UnitEnrollment Enroll(int unitId, int learnerId)
    {
        var newEnrollment = new UnitEnrollment(learnerId, unitId);
        _enrollmentRepository.Create(newEnrollment);

        //UoW - generate masteries
        return newEnrollment;
    }

    public Result Unenroll(int unitId, int learnerId, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);
        //Instead of delete maybe only change status?
        var enrollment = _enrollmentRepository.GetEnrollment(unitId, learnerId);
        if (enrollment is null) return Result.Fail(FailureCode.NotFound);
        _enrollmentRepository.DeleteEnrollment(enrollment);

        return Result.Ok();
    }
}