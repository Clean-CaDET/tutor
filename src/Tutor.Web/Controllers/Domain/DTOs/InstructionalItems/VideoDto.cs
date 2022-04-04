using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructionalItems
{
    [JsonDiscriminator("video")]
    public class VideoDto : InstructionalItemDto
    {
        public string Url { get; set; }
    }
}