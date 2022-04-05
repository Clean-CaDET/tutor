using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ArrangeTasks
{
    [JsonDiscriminator("arrangeTask", Policy = DiscriminatorPolicy.Always)]
    public class AtDto : AssessmentItemDto
    {
        public string Text { get; set; }
        public List<AtContainerDto> Containers { get; set; }
        public List<AtElementDto> UnarrangedElements { get; set; }
    }
}