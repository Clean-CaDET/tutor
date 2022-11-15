namespace Tutor.Core.Domain.Stakeholders;

public interface IInstructorRepository
{
    Instructor GetByUserId(int userId);
}