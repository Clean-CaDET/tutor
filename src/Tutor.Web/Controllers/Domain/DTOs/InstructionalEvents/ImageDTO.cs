
using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents
{
    [JsonDiscriminator("image")]
    public class ImageDTO : InstructionalEventDTO
    {
        public string Url { get; set; }
        public string Caption { get; set; }
    }
}