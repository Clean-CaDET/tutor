namespace Tutor.Core.LearnerModel
{
    public interface ILearnerRepository
    {
        Learner GetByUserId(int userId);
        Learner GetByIndex(string index);
        Learner Save(Learner learner);
    }
}
