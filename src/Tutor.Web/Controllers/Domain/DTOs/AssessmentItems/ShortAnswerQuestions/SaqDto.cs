using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ShortAnswerQuestions
{
    [JsonDiscriminator("shortAnswerQuestion", Policy = DiscriminatorPolicy.Always)]
    public class SaqDto : AssessmentItemDto
    {
        public string Text { get; set; }
    }
}