using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Interfaces.Management;

public interface IGroupMembershipService
{
    Result<List<LearnerDto>> GetGroupMembers(int groupId);
    Result CreateMembers(int groupId, List<int> learnerIds);
    Result DeleteMember(int groupId, int learnerId);
}