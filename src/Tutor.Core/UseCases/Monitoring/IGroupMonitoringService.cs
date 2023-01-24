using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Monitoring;

public interface IGroupMonitoringService
{
    Result<List<LearnerGroup>> GetCourseGroups(int instructorId, int courseId);
    Result<PagedResult<Learner>> GetLearnersWithProgress(int courseId, int instructorId, int page, int pageSize);
    Result<PagedResult<Learner>> GetLearnersWithProgressForGroup(int courseId, int instructorId, int groupId, int page, int pageSize);
}