using Dahomey.Json.Attributes;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge
{
    [JsonDiscriminator("challenge")]
    public class ChallengeDTO : AssessmentEventDTO
    {
        public string Url { get; set; }
        public string Description { get; set; }
    }
}