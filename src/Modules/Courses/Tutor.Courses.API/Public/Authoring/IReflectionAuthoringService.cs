using FluentResults;
using Tutor.Courses.API.Dtos.Reflections;

namespace Tutor.Courses.API.Public.Authoring;

public interface IReflectionAuthoringService
{
    Result<List<ReflectionDto>> GetByUnit(int unitId, int instructorId);
    Result<ReflectionDto> Create(ReflectionDto reflection, int instructorId);
    Result<ReflectionDto> Update(ReflectionDto reflection, int instructorId);
    Result Delete(int id, int instructorId);
    Result<List<ReflectionQuestionCategoryDto>> GetCategories();
}