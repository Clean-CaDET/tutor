using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

namespace Tutor.KnowledgeComponents.API.Public.Learning;

public interface IInstructionService
{
    Result<List<InstructionalItemDto>> GetByKc(int kcId, int learnerId);
}