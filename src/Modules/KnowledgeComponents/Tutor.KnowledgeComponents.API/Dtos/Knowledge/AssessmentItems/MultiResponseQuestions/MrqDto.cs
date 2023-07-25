namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqDto : AssessmentItemDto
{
    public string Text { get; set; }
    public List<MrqItemDto> Items { get; set; }
}