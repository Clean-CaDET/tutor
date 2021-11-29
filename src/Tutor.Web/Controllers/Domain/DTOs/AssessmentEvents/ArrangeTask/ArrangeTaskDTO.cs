using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask
{
    [JsonDiscriminator("arrangeTask")]
    public class ArrangeTaskDTO : AssessmentEventDTO
    {
        public string Text { get; set; }
        public List<ArrangeTaskContainerDTO> Containers { get; set; }
        public List<ArrangeTaskElementDTO> UnarrangedElements { get; set; }
    }
}