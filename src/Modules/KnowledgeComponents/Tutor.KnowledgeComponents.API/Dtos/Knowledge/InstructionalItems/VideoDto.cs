using System.Text.Json.Serialization;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

[JsonDerivedType(typeof(VideoDto), typeDiscriminator: "video")]
public class VideoDto : InstructionalItemDto
{
    public string Url { get; set; }
    public string Caption { get; set; }

    public override string ToString()
    {
        return Caption;
    }
}