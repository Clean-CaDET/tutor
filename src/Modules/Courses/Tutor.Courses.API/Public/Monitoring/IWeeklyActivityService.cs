using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Monitoring;

namespace Tutor.Courses.API.Public.Monitoring;

public interface IWeeklyActivityService
{
    Result<List<UnitHeaderDto>> GetWeeklyUnitsWithTasksAndKcs(int instructorId, int learnerId, int courseId, DateTime weekEnd);
    Result<List<UnitProgressRatingDto>> GetRecentRatingsForUnits(int instructorId, int[]? unitIds, DateTime weekEnd);
    Result<List<UnitProgressStatisticsDto>> GetKcAndTaskProgressAndWarnings(int instructorId, int[]? unitIds, int learnerId, int[] groupMemberIds);
}