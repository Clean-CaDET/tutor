﻿namespace Tutor.Web.Controllers.Domain.DTOs.Feedback
{
    public class TutorImprovementFeedbackDto
    {
        public int LearnerId { get; set; }
        public int UnitId { get; set; }
        public string SoftwareComment { get; set; }
        public string ContentComment { get; set; }
    }
}