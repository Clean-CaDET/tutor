namespace Tutor.Core.LearnerModel
{
    public interface ILearnerRepository
    {
        Learner Get(int id);
        Learner GetByIndex(string index);
        Learner Save(Learner learner);
    }
}
