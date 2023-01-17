using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.InstructionalItems;

namespace Tutor.Core.UseCases.Management.Knowledge;

public interface IInstructionService
{
    Result<List<InstructionalItem>> GetForKc(int kcId, int instructorId);
    Result<InstructionalItem> Create(InstructionalItem instruction, int instructorId);
    Result<InstructionalItem> Update(InstructionalItem instruction, int instructorId);
    Result<List<InstructionalItem>> UpdateOrdering(int kcId, List<InstructionalItem> items, int instructorId);
    Result Delete(int id, int kcId, int instructorId);
}