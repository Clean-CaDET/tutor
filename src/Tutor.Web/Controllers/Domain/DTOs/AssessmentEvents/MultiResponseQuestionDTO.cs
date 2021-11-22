using System.Collections.Generic;
using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents
{
    [JsonDiscriminator("multiResponseQuestion")]
    public class MultiResponseQuestionDTO : AssessmentEventDTO
    {
        public string Text { get; set; }
        public List<MRQAnswerDTO> PossibleAnswers { get; set; }
    }
}