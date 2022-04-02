using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestions
{
    [JsonDiscriminator("multiResponseQuestion", Policy = DiscriminatorPolicy.Always)]
    public class MrqDto : AssessmentEventDto
    {
        public string Text { get; set; }
        public List<MrqItemDto> Items { get; set; }
    }
}