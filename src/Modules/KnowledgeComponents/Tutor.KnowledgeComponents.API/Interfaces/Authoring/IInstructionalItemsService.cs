using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

namespace Tutor.KnowledgeComponents.API.Interfaces.Authoring;

public interface IInstructionalItemsService
{
    Result<List<InstructionalItemDto>> GetByKc(int kcId, int instructorId);
    Result<InstructionalItemDto> Create(InstructionalItemDto instruction, int instructorId);
    Result<InstructionalItemDto> Update(InstructionalItemDto instruction, int instructorId);
    Result<List<InstructionalItemDto>> UpdateOrdering(List<InstructionalItemDto> items, int instructorId);
    Result Delete(int id, int kcId, int instructorId);
}