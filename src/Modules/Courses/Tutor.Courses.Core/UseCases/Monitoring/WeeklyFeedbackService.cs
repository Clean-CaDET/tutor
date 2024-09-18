using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class WeeklyFeedbackService : CrudService<WeeklyFeedbackDto, WeeklyFeedback>, IWeeklyFeedbackService
{
    private readonly IWeeklyFeedbackRepository _feedbackRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public WeeklyFeedbackService(IWeeklyFeedbackRepository feedbackRepository, IOwnedCourseRepository ownedCourseRepository,
        ICoursesUnitOfWork unitOfWork, IMapper mapper) : base(feedbackRepository, unitOfWork, mapper)
    {
        _feedbackRepository = feedbackRepository;
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<List<WeeklyFeedbackDto>> GetByCourseAndLearner(int courseId, int learnerId, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return MapToDto(_feedbackRepository.GetByCourseAndLearner(courseId, learnerId));
    }

    public Result<WeeklyFeedbackDto> Create(WeeklyFeedbackDto feedback, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(feedback.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        
        return Create(feedback);
    }

    public Result<WeeklyFeedbackDto> Update(WeeklyFeedbackDto feedback, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(feedback.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        
        return Update(feedback);
    }

    public Result Delete(int feedbackId, int instructorId)
    {
        var feedback = _feedbackRepository.Get(feedbackId);
        if (feedback == null || !_ownedCourseRepository.IsCourseOwner(feedback.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        _feedbackRepository.Delete(feedback);
        return UnitOfWork.Save();
    }
}