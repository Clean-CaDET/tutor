using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructionalItems
{
    [JsonDiscriminator("text")]
    public class TextDto : InstructionalItemDto
    {
        public string Content { get; set; }
    }
}