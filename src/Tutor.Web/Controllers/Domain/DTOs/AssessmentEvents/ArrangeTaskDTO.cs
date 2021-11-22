using System.Collections.Generic;
using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents
{
    [JsonDiscriminator("arrangeTask")]
    public class ArrangeTaskDTO : AssessmentEventDTO
    {
        public string Text { get; set; }
        public List<ArrangeTaskContainerDTO> Containers { get; set; }
        public List<ArrangeTaskElementDTO> UnarrangedElements { get; set; }
    }
}