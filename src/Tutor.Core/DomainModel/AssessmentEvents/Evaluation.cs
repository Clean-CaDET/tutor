using System;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public class Evaluation
    {
        public int AssessmentEventId { get; }
        public double CorrectnessLevel { get; }
        public bool Correct => CorrectnessLevel > 0.95;

        public Evaluation(int assessmentEventId, double correctnessLevel)
        {
            if (correctnessLevel < 0 || correctnessLevel > 1) throw new ArgumentException("Invalid value for correctness level: " + correctnessLevel);
            AssessmentEventId = assessmentEventId;
            CorrectnessLevel = correctnessLevel;
        }
    }
}
