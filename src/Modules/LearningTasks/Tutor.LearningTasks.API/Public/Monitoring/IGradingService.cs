using FluentResults;
using Tutor.LearningTasks.API.Dtos.TaskProgress;

namespace Tutor.LearningTasks.API.Public.Monitoring;

public interface IGradingService
{
    Result<List<TaskProgressDto>> GetByUnitAndLearner(int unitId, int learnerId, int instructorId);
    Result<TaskProgressDto> SubmitGrade(int unitId, int progressId, StepProgressDto stepProgress, int instructorId);
    Result<List<TaskProgressDto>> GetGroupSummaries(int[] unitIds, int[] groupMemberIds, int instructorId);
}
