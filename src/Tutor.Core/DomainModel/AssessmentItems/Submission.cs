using System;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public abstract class Submission
    {
        public int Id { get; private set; }
        public int AssessmentItemId { get; private set; }
        public int LearnerId { get; private set; }
        public bool IsCorrect { get; private set; }
        public double CorrectnessLevel { get; private set; }
        public DateTime TimeStamp { get; private set; } = DateTime.Now.ToUniversalTime();

        public void UpdateCorrectness(Evaluation evaluation)
        {
            IsCorrect = evaluation.Correct;
            CorrectnessLevel = evaluation.CorrectnessLevel;
        }
    }
}