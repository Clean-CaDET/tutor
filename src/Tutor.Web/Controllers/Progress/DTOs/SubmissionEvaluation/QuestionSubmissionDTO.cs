﻿using System.Collections.Generic;
using Tutor.Web.Controllers.Content.DTOs;

namespace Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation
{
    public class QuestionSubmissionDTO
    {
        public List<QuestionAnswerDTO> Answers { get; set; }
        public int LearnerId { get; set; }
        public int QuestionId { get; set; }
    }
}