using FluentResults;

namespace Tutor.Courses.API.Public.Learning;

public interface IUnitProgressService
{
    Result<List<int>> GetMasteredUnitIds(List<int> unitIds, int learnerId);
}