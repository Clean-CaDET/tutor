using FluentResults;

namespace Tutor.Courses.API.Public.Learning;

public interface IUnitProgressService
{
    Result<List<int>> CompleteMasteredUnits(int courseId, List<int> unitIds, int learnerId);
}