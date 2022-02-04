using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ShortAnswerQuestion
{
    [JsonDiscriminator("shortAnswerQuestion", Policy = DiscriminatorPolicy.Always)]
    public class ShortAnswerQuestionDto : AssessmentEventDto
    {
        public string Text { get; set; }
    }
}