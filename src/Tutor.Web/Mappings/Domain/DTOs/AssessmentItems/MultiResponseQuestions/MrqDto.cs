using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.MultiResponseQuestions
{
    [JsonDiscriminator("multiResponseQuestion", Policy = DiscriminatorPolicy.Always)]
    public class MrqDto : AssessmentItemDto
    {
        public string Text { get; set; }
        public List<MrqItemDto> Items { get; set; }
    }
}