using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

namespace Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

public class SubmissionCountDto
{
    public int Count { get; set; }
    public SubmissionDto Submission { get; set; }
}