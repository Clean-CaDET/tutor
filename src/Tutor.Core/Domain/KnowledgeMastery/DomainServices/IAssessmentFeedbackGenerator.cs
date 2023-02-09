using FluentResults;
using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.Domain.KnowledgeMastery.DomainServices;

public interface IAssessmentFeedbackGenerator
{
    Result<Feedback> CreateFeedback(AssessmentItemMastery existingMastery, AssessmentItem item, Submission submission);
}