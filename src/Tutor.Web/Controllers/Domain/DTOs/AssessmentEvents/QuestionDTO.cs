using System.Collections.Generic;
using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents
{
    [JsonDiscriminator("question")]
    public class QuestionDTO : AssessmentEventDTO
    {
        public string Text { get; set; }
        public List<QuestionAnswerDTO> PossibleAnswers { get; set; }
    }
}