using System.Text.Json.Serialization;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

[JsonDerivedType(typeof(TextDto), typeDiscriminator: "text")]
public class TextDto : InstructionalItemDto
{
    public string Content { get; set; }

    public override string ToString()
    {
        return Content;
    }
}