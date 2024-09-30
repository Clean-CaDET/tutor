namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;
public class StepGraded : StepEvent
{
    public List<StandardEvaluation> Evaluations { get; private set; }
    public string Comment { get; private set; }

    public StepGraded(int stepId, List<StandardEvaluation> evaluations, string comment)
    {
        StepId = stepId;
        Evaluations = evaluations;
        Comment = comment;
    }
}