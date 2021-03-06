using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructionalItems
{
    [JsonDiscriminator("image")]
    public class ImageDto : InstructionalItemDto
    {
        public string Url { get; set; }
        public string Caption { get; set; }
    }
}