using System;

namespace Tutor.Core.ProgressModel.Exceptions
{
    public class LearnerNotEnrolledInCourse : Exception
    {
        public LearnerNotEnrolledInCourse(int learnerId) : base(
            $"Learner {learnerId} is not enrolled in selected course")
        {
        }
    }
}