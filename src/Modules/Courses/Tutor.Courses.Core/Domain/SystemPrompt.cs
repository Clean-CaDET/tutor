using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class SystemPrompt : Entity
{
    public string Category { get; private set; }
    public string Code { get; private set; }
    public string Content { get; private set; }
}