﻿using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.CourseIteration;

public interface IEnrollmentRepository
{
    int CountAllEnrollmentsInUnit(int unitId);
    List<Course> GetEnrolledCourses(int learnerId);
    Course GetCourseEnrolledAndActiveUnits(int courseId, int learnerId);
    bool HasActiveEnrollmentForUnit(int unitId, int learnerId);
    bool HasActiveEnrollmentForKc(int knowledgeComponentId, int learnerId);
    Result<List<UnitEnrollment>> GetEnrollments(int unitId, int[] learnerIds);
    Result<UnitEnrollment> Create(UnitEnrollment newEnrollment);
    Result DeleteEnrollment(int learnerId, int unitId);
}