using FluentResults;
using Tutor.LearningTasks.API.Dtos.Activities;

namespace Tutor.LearningTasks.API.Public.Authoring;

public interface IActivityService
{
    Result<ActivityDto> GetWithExamples(int id);
    Result<List<ActivityDto>> GetWithExamplesByCourse(int courseId);
    Result<ActivityDto> Create(ActivityDto activity, int instructorId);
    Result Delete(int id, int courseId, int instructorId);
}
