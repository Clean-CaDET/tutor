using FluentResults;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerService
    {
        Result Enroll(int learnerId, int unitId);
        Result<Learner> GetLearnerProfile(int id);
    }
}