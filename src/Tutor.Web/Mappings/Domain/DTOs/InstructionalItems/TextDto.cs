using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Domain.DTOs.InstructionalItems
{
    [JsonDiscriminator("text")]
    public class TextDto : InstructionalItemDto
    {
        public string Content { get; set; }
    }
}