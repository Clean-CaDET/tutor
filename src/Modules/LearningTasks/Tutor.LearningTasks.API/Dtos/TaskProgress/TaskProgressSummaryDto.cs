namespace Tutor.LearningTasks.API.Dtos.TaskProgress
{
    public class TaskProgressSummaryDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public int CompletedSteps { get; set; }
        public int TotalSteps { get; set; }
        public double TotalScore { get; set; }
        public double MaxPoints { get; set; }
    }
}
