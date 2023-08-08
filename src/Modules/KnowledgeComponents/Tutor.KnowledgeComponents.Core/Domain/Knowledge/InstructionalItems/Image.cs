namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;

public class Image : InstructionalItem
{
    public string Url { get; private set; }
    public string Caption { get; private set; }
    public override InstructionalItem Clone()
    {
        return new Image
        {
            Url = Url,
            Caption = Caption,
            Order = Order
        };
    }
}