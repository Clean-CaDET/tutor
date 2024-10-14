using FluentResults;
using Tutor.Courses.API.Dtos.Monitoring;

namespace Tutor.Courses.API.Public.Monitoring;

public interface IWeeklyFeedbackService
{
    Result<List<WeeklyFeedbackDto>> GetByCourseAndLearner(int courseId, int learnerId, int instructorId);
    Result<List<WeeklyFeedbackDto>> GetByGroup(int courseId, int[] groupMemberIds, DateTime weekEnd, int instructorId);
    Result<WeeklyFeedbackDto> Create(WeeklyFeedbackDto feedback, int instructorId);
    Result<WeeklyFeedbackDto> Update(WeeklyFeedbackDto feedback, int instructorId);
    Result Delete(int feedbackId, int instructorId);
}