namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;

public class FeedbackDto
{
    public string Type { get; set; }
    public HintDto Hint { get; set;  }
    public EvaluationDto Evaluation { get; set; }
}