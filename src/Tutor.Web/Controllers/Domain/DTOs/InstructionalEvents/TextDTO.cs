
using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents
{
    [JsonDiscriminator("text")]
    public class TextDTO : InstructionalEventDTO
    {
        public string Content { get; set; }
    }
}