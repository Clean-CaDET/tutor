using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Interfaces.Management;

public interface IGroupMembershipService
{
    Result<List<int>> GetMemberIds(int groupId);
    Result<List<LearnerDto>> GetMembers(int groupId);
    Result CreateMembers(int groupId, List<int> learnerIds);
    Result DeleteMember(int groupId, int learnerId);
}