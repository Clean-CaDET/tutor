using System.Collections.Generic;
using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks
{
    [JsonDiscriminator("arrangeTask", Policy = DiscriminatorPolicy.Always)]
    public class AtDto : AssessmentItemDto
    {
        public string Text { get; set; }
        public List<AtContainerDto> Containers { get; set; }
        public List<AtElementDto> UnarrangedElements { get; set; }
    }
}