using FluentResults;
using Tutor.Courses.API.Dtos.Groups;

namespace Tutor.Courses.API.Public.Management;

public interface IGroupMembershipService
{
    Result<List<LearnerDto>> GetMembers(int groupId);
    Result CreateMembers(int groupId, List<int> learnerIds);
    Result DeleteMember(int groupId, int learnerId);
}