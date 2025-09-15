using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class WeeklyFeedbackQuestion : Entity
{
    public string Category { get; private set; }
    public string Code { get; private set; }
    public string Question { get; private set; }
    public string Type { get; private set; }
    public string? Guidance { get; private set; }
    public string Options { get; private set; }

    public WeeklyFeedbackQuestion(int id, string category, string code, string question, string type, string guidance, string options)
    {
        Id = id;
        Category = category;
        Code = code;
        Question = question;
        Type = type;
        Guidance = guidance;
        Options = options;
    }
}