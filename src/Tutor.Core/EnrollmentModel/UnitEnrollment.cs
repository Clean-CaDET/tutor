using System;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.EnrollmentModel
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
