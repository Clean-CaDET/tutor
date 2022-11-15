using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems
{
    [JsonDiscriminator("video")]
    public class VideoDto : InstructionalItemDto
    {
        public string Url { get; set; }
        public string Caption { get; set; }
    }
}