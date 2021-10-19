using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerRepository
    {
        Learner GetById(int learnerId);
        Learner GetByIndex(string index);
        Learner SaveOrUpdate(Learner learner);
    }
}
