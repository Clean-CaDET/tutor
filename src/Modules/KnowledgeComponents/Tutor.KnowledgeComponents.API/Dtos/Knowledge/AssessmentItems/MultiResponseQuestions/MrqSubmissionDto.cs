namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqSubmissionDto : SubmissionDto
{
    public List<MrqItemDto> Answers { get; set; }
}