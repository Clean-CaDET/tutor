using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents
{
    [JsonDiscriminator("video")]
    public class VideoDto : InstructionalEventDto
    {
        public string Url { get; set; }
    }
}