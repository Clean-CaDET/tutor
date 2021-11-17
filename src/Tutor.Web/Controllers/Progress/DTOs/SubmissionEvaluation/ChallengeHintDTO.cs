using System.Collections.Generic;

namespace Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation
{
    public class ChallengeHintDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<string> ApplicableToCodeSnippets { get; set; }
    }
}
