using System.Collections.Generic;
using FluentResults;

namespace Tutor.Core.Domain.KnowledgeMastery
{
    public interface IAssessmentItemSelector
    {
        Result<int> SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed);
    }
}