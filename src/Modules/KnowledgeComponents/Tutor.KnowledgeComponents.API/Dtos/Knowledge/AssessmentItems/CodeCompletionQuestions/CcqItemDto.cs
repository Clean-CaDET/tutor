namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqItemDto
{
    public int Order { get; set;  }
    public string Answer { get; set; }
    public int Length { get; set; }
    public bool IgnoreSpace { get; set; }
}