using FluentResults;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerService
    {
        Result<Learner> Register(Learner learner);
    }
}