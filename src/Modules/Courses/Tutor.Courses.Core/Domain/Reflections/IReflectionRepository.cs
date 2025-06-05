using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.Reflections;

public interface IReflectionRepository : ICrudRepository<Reflection>
{
    List<Reflection> GetByUnit(int unitId);
    Reflection? GetWithQuestions(int reflectionId);
    
    List<Reflection> GetByUnitWithSubmission(int unitId, int learnerId);
    Reflection? GetWithSubmission(int reflectionId, int learnerId);
    void CreateAnswer(ReflectionAnswer answer);
}