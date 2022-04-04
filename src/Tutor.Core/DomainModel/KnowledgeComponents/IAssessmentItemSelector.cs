using System.Collections.Generic;
using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IAssessmentItemSelector
    {
        AssessmentItem SelectSuitableAssessmentItem(List<AssessmentItem> itemsWithSubmissions);
    }
}