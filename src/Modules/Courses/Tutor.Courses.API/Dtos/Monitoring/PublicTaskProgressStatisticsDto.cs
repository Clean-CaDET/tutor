﻿namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicTaskProgressStatisticsDto
{
    public int TaskId { get; set; }
    public DateTime CompletionTime { get; set; }
    public int WonPoints { get; set; }
    public string[] NegativePatterns { get; set; }
}