using FluentResults;
using Tutor.LearningTasks.API.Dtos.LearningTasks;

namespace Tutor.LearningTasks.API.Public.Authoring;

public interface IActivityService
{
    Result<ActivityDto> Create(ActivityDto activity, int learningTaskId, int instructorId);
    Result<ActivityDto> Update(ActivityDto activity, int learningTaskId, int instructorId);
    Result Delete(int id, int unitId, int learningTaskId, int instructorId);
}