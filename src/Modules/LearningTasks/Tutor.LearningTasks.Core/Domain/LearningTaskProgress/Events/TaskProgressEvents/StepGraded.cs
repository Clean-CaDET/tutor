namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
public class StepGraded : TaskProgressEvent
{
    public int StepId { get; private set; }
    public List<StandardEvaluation> Evaluations { get; private set; }
    public string Comment { get; private set; }

    public StepGraded(int stepId, List<StandardEvaluation> evaluations, string comment)
    {
        StepId = stepId;
        Evaluations = evaluations;
        Comment = comment;
    }
}
