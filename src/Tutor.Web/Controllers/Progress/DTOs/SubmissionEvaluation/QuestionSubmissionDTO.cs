using System.Collections.Generic;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;

namespace Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation
{
    public class QuestionSubmissionDTO
    {
        public List<MRQAnswerDTO> Answers { get; set; }
        public int LearnerId { get; set; }
        public int QuestionId { get; set; }
    }
}