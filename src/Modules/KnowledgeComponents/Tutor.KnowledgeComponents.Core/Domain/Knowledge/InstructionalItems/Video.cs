namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;

public class Video : InstructionalItem
{
    public string Url { get; private set; }
    public string Caption { get; private set; }
}