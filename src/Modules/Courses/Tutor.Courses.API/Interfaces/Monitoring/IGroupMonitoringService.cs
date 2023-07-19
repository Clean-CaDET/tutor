using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Interfaces.Monitoring;

public interface IGroupMonitoringService
{
    Result<List<GroupDto>> GetCourseGroups(int instructorId, int courseId);
    Result<PagedResult<LearnerDto>> GetLearners(int instructorId, int courseId, int groupId, int page, int pageSize);
}