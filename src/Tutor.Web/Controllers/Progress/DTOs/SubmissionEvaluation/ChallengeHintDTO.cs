using System.Collections.Generic;
using Tutor.Web.Controllers.Content.DTOs;

namespace Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation
{
    public class ChallengeHintDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public LearningObjectDTO LearningObject { get; set; }
        public List<string> ApplicableToCodeSnippets { get; set; }
    }
}
