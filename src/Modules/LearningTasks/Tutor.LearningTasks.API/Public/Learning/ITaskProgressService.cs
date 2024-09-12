using FluentResults;
using Tutor.LearningTasks.API.Dtos.TaskProgress;

namespace Tutor.LearningTasks.API.Public.Learning;

public interface ITaskProgressService
{
    Result<TaskProgressDto> GetOrCreate(int unitId, int taskId, int learnerId);
    Result<TaskProgressDto> ViewStep(int unitId, int id, int stepId, int learnerId);
    Result<TaskProgressDto> SubmitAnswer(int unitId, int id, StepProgressDto stepProgress, int learnerId);
    Result OpenSubmission(int unitId, int id, int stepId, int learnerId);
    Result OpenGuidance(int unitId, int id, int stepId, int learnerId);
    Result OpenExample(int unitId, int id, int stepId, int learnerId);
    Result PlayExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl);
    Result PauseExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl);
    Result FinishExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl);
}
