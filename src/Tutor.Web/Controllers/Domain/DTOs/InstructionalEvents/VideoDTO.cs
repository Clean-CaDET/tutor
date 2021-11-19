
using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents
{
    [JsonDiscriminator("video")]
    public class VideoDTO : InstructionalEventDTO
    {
        public string Url { get; set; }
    }
}