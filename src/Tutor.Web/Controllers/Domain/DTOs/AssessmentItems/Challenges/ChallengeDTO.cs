using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.Challenges
{
    [JsonDiscriminator("challenge", Policy = DiscriminatorPolicy.Always)]
    public class ChallengeDto : AssessmentItemDto
    {
        public string Url { get; set; }
        public string Description { get; set; }
    }
}