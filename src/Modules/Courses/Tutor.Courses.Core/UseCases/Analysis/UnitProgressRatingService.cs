using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Analysis;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.LearningTasks.API.Internal;

namespace Tutor.Courses.Core.UseCases.Analysis;

public class UnitProgressRatingService : IUnitProgressRatingService
{
    private readonly IUnitEnrollmentRepository _enrollmentRepository;
    private readonly IUnitProgressRatingRepository _ratingRepository;
    private readonly IKnowledgeMasteryQuerier _kcMasteryQuerier;
    private readonly ITaskProgressQuerier _taskProgressQuerier;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UnitProgressRatingService(IUnitEnrollmentRepository enrollmentRepository, IUnitProgressRatingRepository ratingRepository,
        IKnowledgeMasteryQuerier kcMasteryQuerier, ITaskProgressQuerier taskProgressQuerier,
        ICoursesUnitOfWork unitOfWork, IMapper mapper)
    {
        _enrollmentRepository = enrollmentRepository;
        _ratingRepository = ratingRepository;
        _kcMasteryQuerier = kcMasteryQuerier;
        _taskProgressQuerier = taskProgressQuerier;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<UnitFeedbackRequestDto> ShouldRequestFeedback(int unitId, int learnerId)
    {
        if (!HasActiveEnrollment(unitId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcMasteryCount = _kcMasteryQuerier.CountTotalAndSatisfied(unitId, learnerId).Value;
        var taskProgressCount = _taskProgressQuerier.CountTotalAndCompleted(unitId, learnerId).Value;
        var ratings = _ratingRepository.GetByUnitAndLearner(unitId, learnerId);

        var feedbackRequest = UnitFeedbackRequestor.ShouldRequestFeedback(kcMasteryCount, taskProgressCount, ratings).Value;

        return _mapper.Map<UnitFeedbackRequestDto>(feedbackRequest);
    }

    public Result<UnitProgressRatingDto> Create(UnitProgressRatingDto rating, int learnerId)
    {
        if (!HasActiveEnrollment(rating.KnowledgeUnitId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        rating.LearnerId = learnerId;
        rating.Created = DateTime.UtcNow;
        if (!rating.IsLearnerInitiated)
        {
            RemovePreviouslyRatedKcsAndTasks(rating, learnerId);
        }
        var newRating = _ratingRepository.Create(_mapper.Map<UnitProgressRating>(rating));
        var result = _unitOfWork.Save();

        if (result.IsFailed) return result;
        return _mapper.Map<UnitProgressRatingDto>(newRating);
    }

    private void RemovePreviouslyRatedKcsAndTasks(UnitProgressRatingDto rating, int learnerId)
    {
        var ratings = _ratingRepository.GetByUnitAndLearner(rating.KnowledgeUnitId, learnerId);
        var ratedKcs = ratings.SelectMany(r => r.CompletedKcIds).Distinct();
        var ratedTasks = ratings.SelectMany(r => r.CompletedTaskIds).Distinct();
        rating.CompletedKcIds = rating.CompletedKcIds.Except(ratedKcs).ToArray();
        rating.CompletedTaskIds = rating.CompletedTaskIds.Except(ratedTasks).ToArray();
    }

    public bool HasActiveEnrollment(int unitId, int learnerId)
    {
        var enrollment = _enrollmentRepository.Get(unitId, learnerId);
        return enrollment != null && enrollment.IsAccessible();
    }
}