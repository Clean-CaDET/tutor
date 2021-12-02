using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge
{
    public class ChallengeHintDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<string> ApplicableToCodeSnippets { get; set; }
    }
}
