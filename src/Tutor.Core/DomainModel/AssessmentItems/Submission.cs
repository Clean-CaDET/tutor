﻿using System;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public abstract class Submission
    {
        public int Id { get; protected set; }
        public int AssessmentItemId { get; protected set; }
        public int LearnerId { get; protected set; }
        public bool IsCorrect { get; protected set; }
        public double CorrectnessLevel { get; set; }
        public DateTime TimeStamp { get; private set; } = DateTime.Now.ToUniversalTime();

        public void MarkCorrect()
        {
            IsCorrect = true;
        }
    }
}