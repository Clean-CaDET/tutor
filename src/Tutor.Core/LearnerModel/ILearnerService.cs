using FluentResults;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerService
    {
        Result<Learner> Register(Learner learner);
        Result<Learner> Login(string studentIndex);
    }
}