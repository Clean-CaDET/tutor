using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.AIMicroChallenges
{
    [JsonDiscriminator("aimicrochallenge", Policy=DiscriminatorPolicy.Always)]
    public class AIMicroChallengeDto : AssessmentItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StarterSourceCode { get; set; }
        public bool HasTransformer { get; set; }
    }
}
