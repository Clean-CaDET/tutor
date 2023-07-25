using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

namespace Tutor.KnowledgeComponents.API.Interfaces.Learning;

public interface IInstructionService
{
    Result<List<InstructionalItemDto>> GetInstructionalItems(int kcId, int learnerId);
}