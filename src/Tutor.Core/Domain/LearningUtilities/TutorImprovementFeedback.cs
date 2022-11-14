using System;

namespace Tutor.Core.Domain.LearningUtilities
{
    public class TutorImprovementFeedback
    {
        public int Id { get; private set; }
        public int LearnerId { get; private set; }
        public int UnitId { get; private set; }
        public string SoftwareComment { get; private set; }
        public string ContentComment { get; private set; }
        public DateTime TimeStamp { get; private set; } = DateTime.Now.ToUniversalTime();
    }
}
