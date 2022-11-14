using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Core.UseCases.ProgressMonitoring;

public interface IGroupMonitoringService
{
    Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId);
}