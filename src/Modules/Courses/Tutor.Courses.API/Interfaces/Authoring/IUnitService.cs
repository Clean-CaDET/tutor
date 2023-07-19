using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Interfaces.Authoring;

public interface IUnitService
{
    Result<KnowledgeUnitDto> Create(KnowledgeUnitDto unit, int instructorId);
    Result<KnowledgeUnitDto> Update(KnowledgeUnitDto unit, int instructorId);
    Result Delete(int id, int instructorId);
}