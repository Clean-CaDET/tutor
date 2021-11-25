using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion
{
    [JsonDiscriminator("multiResponseQuestion")]
    public class MultiResponseQuestionDTO : AssessmentEventDTO
    {
        public string Text { get; set; }
        public List<MRQItemDTO> Items { get; set; }
    }
}