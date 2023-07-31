using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Management;

public interface IGroupService
{
    Result<List<GroupDto>> GetByCourse(int courseId);
    Result<GroupDto> Create(GroupDto group);
    Result<GroupDto> UpdateName(int groupId, string name);
    Result Delete(int id);
}