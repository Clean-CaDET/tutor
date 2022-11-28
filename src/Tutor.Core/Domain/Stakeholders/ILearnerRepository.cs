namespace Tutor.Core.Domain.Stakeholders;

public interface ILearnerRepository
{
    Learner GetByUserId(int userId);
    Learner GetByIndex(string index);
}