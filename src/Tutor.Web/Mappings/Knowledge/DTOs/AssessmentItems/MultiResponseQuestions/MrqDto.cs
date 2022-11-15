using System.Collections.Generic;
using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions
{
    [JsonDiscriminator("multiResponseQuestion", Policy = DiscriminatorPolicy.Always)]
    public class MrqDto : AssessmentItemDto
    {
        public string Text { get; set; }
        public List<MrqItemDto> Items { get; set; }
    }
}