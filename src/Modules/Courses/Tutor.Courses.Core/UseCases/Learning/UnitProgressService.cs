using FluentResults;
using Tutor.Courses.API.Public.Learning;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.LearningTasks.API.Internal;

namespace Tutor.Courses.Core.UseCases.Learning;

public class UnitProgressService : IUnitProgressService
{
    private readonly IKnowledgeMasteryQuerier _kcMasteryQuerier;
    private readonly ITaskProgressQuerier _taskProgressQuerier;
    private readonly IUnitEnrollmentRepository _enrollmentRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;


    public UnitProgressService(IKnowledgeMasteryQuerier kcMasteryQuerier, ITaskProgressQuerier taskProgressQuerier,
        IUnitEnrollmentRepository enrollmentRepository, ICoursesUnitOfWork unitOfWork)
    {
        _kcMasteryQuerier = kcMasteryQuerier;
        _taskProgressQuerier = taskProgressQuerier;
        _enrollmentRepository = enrollmentRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<List<int>> CompleteMasteredUnits(int courseId, List<int> unitIds, int learnerId)
    {
        var activeEnrollments = GetActiveEnrollments(courseId, unitIds, learnerId);
        if (activeEnrollments.Count == 0) return new List<int>();

        var completedUnitIds = GetMasteredUnitIds(learnerId, activeEnrollments);
        if(completedUnitIds.Count == 0) return new List<int>();

        var result = CompleteEnrollments(activeEnrollments, completedUnitIds);
        if (result.IsFailed) return result;

        return completedUnitIds;
    }

    private List<UnitEnrollment> GetActiveEnrollments(int courseId, List<int> unitIds, int learnerId)
    {
        return _enrollmentRepository
            .GetEnrolledUnits(courseId, learnerId)
            .Where(e => e.Status == EnrollmentStatus.Active && unitIds.Contains(e.KnowledgeUnitId))
            .ToList();
    }

    private List<int> GetMasteredUnitIds(int learnerId, List<UnitEnrollment> activeEnrollments)
    {
        var candidateUnits = activeEnrollments.Select(e => e.KnowledgeUnitId).ToArray();
        var masteredKcUnits = _kcMasteryQuerier.GetMasteredUnitIds(candidateUnits, learnerId).Value;
        var completedTaskUnits = _taskProgressQuerier.GetCompletedUnitIds(candidateUnits, learnerId).Value;
        return masteredKcUnits.Intersect(completedTaskUnits).ToList();
    }

    private Result CompleteEnrollments(List<UnitEnrollment> activeEnrollments, List<int> completedUnitIds)
    {
        activeEnrollments.ForEach(e =>
        {
            if (!completedUnitIds.Contains(e.KnowledgeUnitId)) return;
            e.Status = EnrollmentStatus.Completed;
            _enrollmentRepository.Update(e);
        });
        return _unitOfWork.Save();
    }
}