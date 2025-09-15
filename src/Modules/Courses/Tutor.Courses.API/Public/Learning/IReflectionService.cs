using FluentResults;
using Tutor.Courses.API.Dtos.Reflections;

namespace Tutor.Courses.API.Public.Learning;

public interface IReflectionService
{
    Result<List<ReflectionDto>> GetAll(int unitId, int learnerId);
    Result<ReflectionDto> GetWithSubmission(int reflectionId, int learnerId);
    Result SubmitAnswer(ReflectionAnswerDto answer);
}