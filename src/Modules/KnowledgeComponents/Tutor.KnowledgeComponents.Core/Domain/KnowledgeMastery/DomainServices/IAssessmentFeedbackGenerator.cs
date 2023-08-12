using FluentResults;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

public interface IAssessmentFeedbackGenerator
{
    Result<Feedback> CreateFeedback(AssessmentItemMastery existingMastery, AssessmentItem item, Submission submission);
}