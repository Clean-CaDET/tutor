namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;

public class Markdown : InstructionalItem
{
    public string Content { get; private set; }
    public override InstructionalItem Clone()
    {
        return new Markdown
        {
            Content = Content,
            Order = Order
        };
    }
}