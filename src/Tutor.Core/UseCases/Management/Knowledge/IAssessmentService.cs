using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.UseCases.Management.Knowledge;

public interface IAssessmentService
{
    Result<List<AssessmentItem>> GetForKc(int kcId, int instructorId);
    /*Result<InstructionalItem> Create(InstructionalItem instruction, int instructorId);
    Result<InstructionalItem> Update(InstructionalItem instruction, int instructorId);*/
    Result<List<AssessmentItem>> UpdateOrdering(int kcId, List<AssessmentItem> items, int instructorId);
    // Result Delete(int id, int kcId, int instructorId);
}