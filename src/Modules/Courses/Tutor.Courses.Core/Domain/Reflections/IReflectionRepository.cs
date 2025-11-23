using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.Reflections;

public interface IReflectionRepository : ICrudRepository<Reflection>
{
    List<Reflection> GetByUnit(int unitId);
    List<Reflection> GetByUnitsWithQuestions(int[] unitIds);
    List<Reflection> GetByUnitsWithAnswers(int[] unitIds);
    Reflection? GetWithQuestions(int reflectionId);
    
    List<Reflection> GetByUnitWithAnswers(int unitId, int learnerId);
    List<Reflection> GetByUnitsWithQAndA(int[] unitIds, int learnerId);
    Reflection? GetWithAnswers(int reflectionId, int learnerId);
    List<Reflection> GetManyWithAnswers(List<int> reflectionIds, int learnerId);
    void CreateAnswer(ReflectionAnswer answer);
}