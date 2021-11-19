﻿using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents
{
    public class QuestionDTO : AssessmentEventDTO
    {
        public string Text { get; set; }
        public List<QuestionAnswerDTO> PossibleAnswers { get; set; }
    }
}