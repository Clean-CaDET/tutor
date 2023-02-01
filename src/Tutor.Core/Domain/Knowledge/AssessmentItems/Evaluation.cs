using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems;

public class Evaluation : ValueObject
{
    public double CorrectnessLevel { get; }
    public bool Correct => CorrectnessLevel >= 0.9;

    public Evaluation(double correctnessLevel)
    {
        if (correctnessLevel < 0 || correctnessLevel > 1) throw new ArgumentException("Invalid value for correctness level: " + correctnessLevel);
        CorrectnessLevel = Math.Round(correctnessLevel, 2);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CorrectnessLevel;
    }
}