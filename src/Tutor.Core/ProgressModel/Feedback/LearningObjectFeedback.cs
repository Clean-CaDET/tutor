using System;

namespace Tutor.Core.ProgressModel.Feedback
{
    public class LearningObjectFeedback
    {
        //TODO: Redesign feedback, for example:
        //- AEs can be briefly rated for challenge level;
        //- All IEs can be rated for clarity
        //- Once a KC is completed, a textarea for broad comments
        public int Id { get; private set; }
        public int Rating { get; private set; }
        public int LearnerId { get; private set; }
        public int LearningObjectId { get; private set; }
        public DateTime TimeStamp { get; private set; } = DateTime.Now;

        public void UpdateRating(int feedbackRating)
        {
            Rating = feedbackRating;
            TimeStamp = DateTime.Now;
        }
    }
}