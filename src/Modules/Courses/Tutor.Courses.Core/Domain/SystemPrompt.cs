using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class SystemPrompt : Entity
{
    public string Category { get; private set; }
    public string Code { get; private set; }
    public string Content { get; private set; }

    public SystemPrompt(int id, string category, string code, string content)
    {
        Id = id;
        Category = category;
        Code = code;
        Content = content;
    }
}