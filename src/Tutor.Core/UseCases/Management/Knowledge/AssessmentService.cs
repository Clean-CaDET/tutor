using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Knowledge;

public class AssessmentService : IAssessmentService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IAssessmentItemRepository _assessmentItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssessmentService(IAssessmentItemRepository assessmentItemRepository, IOwnedCourseRepository ownedCourseRepository, IUnitOfWork unitOfWork)
    {
        _assessmentItemRepository = assessmentItemRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<List<AssessmentItem>> GetForKc(int kcId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return _assessmentItemRepository.GetDerivedAssessmentItemsForKc(kcId);
    }

    public Result<AssessmentItem> Create(AssessmentItem item, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(item.KnowledgeComponentId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        _assessmentItemRepository.Create(item);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return item;
    }
    
    public Result<AssessmentItem> Update(AssessmentItem item, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(item.KnowledgeComponentId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        _assessmentItemRepository.Update(item);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return item;
    }

    public Result<List<AssessmentItem>> UpdateOrdering(int kcId, List<AssessmentItem> items, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        foreach (var assessmentItem in items)
        {
            _assessmentItemRepository.Update(assessmentItem);
        }

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(items);
    }

    public Result Delete(int id, int kcId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var assessment = _assessmentItemRepository.Get(id);
        if (assessment == null) return Result.Fail(FailureCode.NotFound);
        if (assessment.KnowledgeComponentId != kcId)
            return Result.Fail(FailureCode.NotFound);
        
        _assessmentItemRepository.Delete(id);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}