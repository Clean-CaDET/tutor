using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.UseCases.CourseIterationManagement;

public interface IEnrollmentService
{
    Result<List<Course>> GetEnrolledCourses(int learnerId);
    Result<List<KnowledgeUnit>> GetActiveUnits(int courseId, int learnerId);
}