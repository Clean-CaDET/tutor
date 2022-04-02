using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ShortAnswerQuestions
{
    [JsonDiscriminator("shortAnswerQuestion", Policy = DiscriminatorPolicy.Always)]
    public class SaqDto : AssessmentEventDto
    {
        public string Text { get; set; }
    }
}