using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Interfaces.Management;

public interface IGroupService
{
    Result<List<GroupDto>> GetByCourse(int courseId);
    Result<GroupDto> Create(GroupDto group);
    Result<GroupDto> Update(GroupDto group);
    Result Delete(int id);
}