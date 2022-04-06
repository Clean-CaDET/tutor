namespace Tutor.Core.LearnerModel
{
    public interface ILearnerRepository
    {
        Learner GetByIndex(string index);
        Learner Save(Learner learner);
        Learner GetLearnerProfile(int id);
    }
}
