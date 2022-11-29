using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.CourseIteration;

public interface IEnrollmentService
{
    Result<List<Course>> GetEnrolledCourses(int learnerId);
    Result<List<KnowledgeUnit>> GetActiveUnits(int courseId, int learnerId);
}