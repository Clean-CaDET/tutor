using System;

namespace Tutor.Web.Mappings.KnowledgeMastery
{
    public class AssessmentItemMasteryDto
    {
        public int AssessmentItemId { get; set; }
        public int SubmissionCount { get; set; }
        public double Mastery { get; set; }
        public DateTime LastSubmissionTime { get; set; }

        protected bool Equals(AssessmentItemMasteryDto other)
        {
            return AssessmentItemId == other.AssessmentItemId && SubmissionCount == other.SubmissionCount &&
                   Mastery.Equals(other.Mastery) && LastSubmissionTime.Equals(other.LastSubmissionTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AssessmentItemMasteryDto)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AssessmentItemId, SubmissionCount, Mastery, LastSubmissionTime);
        }
    }
}
