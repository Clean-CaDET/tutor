﻿using System.Collections.Generic;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;

namespace Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation
{
    public class ArrangeTaskSubmissionDTO
    {
        public int ArrangeTaskId { get; set; }
        public int LearnerId { get; set; }
        public List<ArrangeTaskContainerDTO> Containers { get; set; }
    }
}