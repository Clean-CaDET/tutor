namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface ILearnerRepository
{
    Learner GetByUserId(int userId);
    Learner GetByIndex(string index);
}