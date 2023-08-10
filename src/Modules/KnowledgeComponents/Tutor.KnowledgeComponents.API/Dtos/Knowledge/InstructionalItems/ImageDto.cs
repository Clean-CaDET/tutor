using System.Text.Json.Serialization;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

[JsonDerivedType(typeof(ImageDto), typeDiscriminator: "image")]
public class ImageDto : InstructionalItemDto
{
    public string Url { get; set; }
    public string Caption { get; set; }

    public override string ToString()
    {
        return Caption;
    }
}