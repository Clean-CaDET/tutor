using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Authoring;

public interface IUnitService
{
    Result<KnowledgeUnitDto> Create(KnowledgeUnitDto unit, int instructorId);
    Result<KnowledgeUnitDto> Update(KnowledgeUnitDto unit, int instructorId);
    Result Delete(int id, int instructorId);
    Result<List<KnowledgeUnitDto>> GetUnitsForWeek(int courseId, int learnerId, DateTime date, int instructorId);
}