using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Courses;

public interface ICourseService
{
    Result<PagedResult<Course>> GetAll(int page, int pageSize);
    Result<Course> CreateWithGroup(Course course);
    Result<Course> Clone(int courseId, Course course);
    Result<Course> Update(Course course);
    Result<Course> Archive(int id, bool archive);
    Result Delete(int id);
}