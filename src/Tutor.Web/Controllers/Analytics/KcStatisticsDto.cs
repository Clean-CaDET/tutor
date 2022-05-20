﻿namespace Tutor.Web.Controllers.Analytics
{
    public class KcStatisticsDto
    {
        public string KcCode { get; set; }
        public string KcName { get; set; }
        public int TotalRegistered { get; set; }
        public int TotalStarted { get; set; }
        public int TotalCompleted { get; set; }
        public int TotalPassed { get; set; }
    }
}