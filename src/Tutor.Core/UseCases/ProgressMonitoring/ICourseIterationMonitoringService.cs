using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.ProgressMonitoring;

public interface ICourseIterationMonitoringService
{
    Result<List<LearnerGroup>> GetCourseGroups(int instructorId, int courseId);
    PagedResult<Learner> GetLearnersWithProgress(int courseId, int page, int pageSize);
    PagedResult<Learner> GetLearnersWithProgressForGroup(int courseId, int groupId, int page, int pageSize);
}