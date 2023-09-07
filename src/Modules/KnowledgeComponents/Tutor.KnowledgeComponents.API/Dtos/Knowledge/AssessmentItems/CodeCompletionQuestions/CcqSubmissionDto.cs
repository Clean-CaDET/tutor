namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqSubmissionDto : SubmissionDto
{
    public CcqItemDto[] Items { get; set; }
}