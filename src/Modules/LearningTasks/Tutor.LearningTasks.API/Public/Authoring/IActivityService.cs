using FluentResults;
using Tutor.LearningTasks.API.Dtos.Activities;

namespace Tutor.LearningTasks.API.Public.Authoring;

public interface IActivityService
{
    Result<ActivityDto> Get(int id);
    Result<List<ActivityDto>> GetByCourse(int courseId);
    Result<List<ActivityDto>> GetSubactivities(int id);
    Result<ActivityDto> Create(ActivityDto activity, int instructorId);
    Result<ActivityDto> Update(ActivityDto activity, int instructorId);
    Result Delete(int id, int courseId, int instructorId);
}
