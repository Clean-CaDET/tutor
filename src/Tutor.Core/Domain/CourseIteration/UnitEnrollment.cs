using System;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.Domain.CourseIteration
{
    public class UnitEnrollment
    {
        public int Id { get; private set; }
        public int LearnerId { get; private set; }
        public KnowledgeUnit KnowledgeUnit { get; private set; }
        public DateTime Start { get; private set; }
        public EnrollmentStatus Status { get; private set; }
    }

    public enum EnrollmentStatus
    {
        Hidden, Active, Passed
    }
}
