using System.Text.Json.Serialization;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

[JsonDerivedType(typeof(InstructionalItemDto), typeDiscriminator: "base")]
[JsonDerivedType(typeof(TextDto), typeDiscriminator: "text")]
[JsonDerivedType(typeof(ImageDto), typeDiscriminator: "image")]
[JsonDerivedType(typeof(VideoDto), typeDiscriminator: "video")]
public class InstructionalItemDto
{
    public int Id { get; set; }
    public int KnowledgeComponentId { get; set; }
    public int Order { get; set; }
}