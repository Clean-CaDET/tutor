using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask
{
    [JsonDiscriminator("arrangeTask")]
    public class ArrangeTaskDto : AssessmentEventDto
    {
        public string Text { get; set; }
        public List<ArrangeTaskContainerDto> Containers { get; set; }
        public List<ArrangeTaskElementDto> UnarrangedElements { get; set; }
    }
}