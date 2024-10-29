using FluentResults;
using Tutor.Courses.API.Dtos.Groups;

namespace Tutor.Courses.API.Public.Monitoring;

public interface ICourseMonitoringService
{
    Result<List<GroupDto>> GetGroupedLearnerFeedback(int courseId);
}