using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems
{
    [JsonDiscriminator("text")]
    public class TextDto : InstructionalItemDto
    {
        public string Content { get; set; }
    }
}