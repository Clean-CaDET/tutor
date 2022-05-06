using FluentResults;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerService
    {
        Result<Learner> GetLearnerProfile(int id);
    }
}