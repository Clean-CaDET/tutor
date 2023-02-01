using System.Collections.Generic;

namespace Tutor.Core.Domain.KnowledgeMastery;

public interface IAssessmentItemSelector
{
    int SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed);
}