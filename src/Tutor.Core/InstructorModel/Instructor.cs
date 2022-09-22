﻿using System.Collections.Generic;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;

namespace Tutor.Core.InstructorModel;

public class Instructor
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public List<LearnerGroup> Groups { get; private set; }
}