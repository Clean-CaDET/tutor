using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents
{
    [JsonDiscriminator("text")]
    public class TextDto : InstructionalEventDto
    {
        public string Content { get; set; }
    }
}