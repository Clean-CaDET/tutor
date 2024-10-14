using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class WeeklyFeedbackService : CrudService<WeeklyFeedbackDto, WeeklyFeedback>, IWeeklyFeedbackService
{
    private readonly IInternalInstructorService _instructorService;
    private readonly IWeeklyFeedbackRepository _feedbackRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public WeeklyFeedbackService(IInternalInstructorService instructorService, IWeeklyFeedbackRepository feedbackRepository, IOwnedCourseRepository ownedCourseRepository,
        ICoursesUnitOfWork unitOfWork, IMapper mapper) : base(feedbackRepository, unitOfWork, mapper)
    {
        _instructorService = instructorService;
        _feedbackRepository = feedbackRepository;
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<List<WeeklyFeedbackDto>> GetByCourseAndLearner(int courseId, int learnerId, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return MapToDto(_feedbackRepository.GetByCourseAndLearner(courseId, learnerId));
    }

    public Result<List<WeeklyFeedbackDto>> GetByGroup(int courseId, int[] groupMemberIds, DateTime weekEnd, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return MapToDto(_feedbackRepository.GetByCourseAndLearners(courseId, groupMemberIds, weekEnd.AddDays(-2), weekEnd.AddDays(2)));
    }

    public Result<WeeklyFeedbackDto> Create(WeeklyFeedbackDto feedback, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(feedback.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        UpdateInstructor(feedback, instructorId);
        return Create(feedback);
    }

    public Result<WeeklyFeedbackDto> Update(WeeklyFeedbackDto feedback, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(feedback.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        UpdateInstructor(feedback, instructorId);
        return Update(feedback);
    }

    private void UpdateInstructor(WeeklyFeedbackDto feedback, int instructorId)
    {
        var instructor = _instructorService.Get(instructorId).Value;
        if(instructor == null) return;
        feedback.InstructorId = instructorId;
        feedback.InstructorName = $"{instructor.Name} {instructor.Surname}";
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