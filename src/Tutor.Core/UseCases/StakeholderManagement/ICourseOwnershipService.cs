using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.UseCases.StakeholderManagement;

public interface ICourseOwnershipService
{
    Result<List<Course>> GetOwnedCourses(int instructorId);
}