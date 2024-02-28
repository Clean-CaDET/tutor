using FluentResults;
using Tutor.LearningTasks.API.Dtos.Activities;

namespace Tutor.LearningTasks.API.Public.Authoring;

public interface IActivityService
{
    Result<ActivityDto> Get(int id, int courseId, int instructorId);
    Result<List<ActivityDto>> GetByCourse(int courseId, int instructorId);
    Result<ActivityDto> Create(ActivityDto activity, int instructorId);
    Result<ActivityDto> Update(ActivityDto activity, int instructorId);
    Result Delete(int id, int courseId, int instructorId);
}
