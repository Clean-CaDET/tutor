﻿using Tutor.Courses.API.Dtos.Monitoring;

namespace Tutor.Courses.API.Dtos.Groups;

public class LearnerDto
{
    public int Id { get; set; }
    public string Index { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<WeeklyFeedbackDto>? WeeklyFeedback { get; set; }
}