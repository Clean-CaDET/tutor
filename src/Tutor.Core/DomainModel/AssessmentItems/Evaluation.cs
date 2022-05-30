using System;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public abstract class Evaluation
    {
        public double CorrectnessLevel { get; }
        public bool Correct => CorrectnessLevel >= 0.9;

        protected Evaluation(double correctnessLevel)
        {
            if (correctnessLevel < 0 || correctnessLevel > 1) throw new ArgumentException("Invalid value for correctness level: " + correctnessLevel);
            CorrectnessLevel = Math.Round(correctnessLevel, 2);
        }
    }
}
