using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.UseCases.StakeholderManagement;

public interface IAvailableCourseService
{
    Result<List<Course>> GetOwnedCourses(int instructorId);
    Result<List<Course>> GetEnrolledCourses(int learnerId);
}