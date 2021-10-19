using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerService
    {
        Learner Register(Learner learner);
        Learner Login(string studentIndex);
    }
}