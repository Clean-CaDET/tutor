using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.Reflections;

public interface IReflectionRepository : ICrudRepository<Reflection>
{
    List<Reflection> GetByUnit(int unitId);
    List<Reflection> GetByUnitsWithQuestions(int[] unitIds);
    List<Reflection> GetByUnitsWithSubmissions(int[] unitIds);
    Reflection? GetWithQuestions(int reflectionId);
    
    List<Reflection> GetByUnitWithSubmission(int unitId, int learnerId);
    Reflection? GetWithSubmission(int reflectionId, int learnerId);
    List<Reflection> GetManyWithSubmission(List<int> reflectionIds, int learnerId);
    void CreateAnswer(ReflectionAnswer answer);
}