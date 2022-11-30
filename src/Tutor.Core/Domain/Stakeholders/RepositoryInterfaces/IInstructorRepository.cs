namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IInstructorRepository
{
    Instructor GetByUserId(int userId);
}