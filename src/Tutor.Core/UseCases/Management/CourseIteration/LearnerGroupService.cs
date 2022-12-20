using System.Collections.Generic;
using FluentResults;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Core.UseCases.Management.CourseIteration;

public class LearnerGroupService: CrudService<LearnerGroup>, ILearnerGroupService
{
    private readonly IGroupRepository _groupRepository;

    public LearnerGroupService(IGroupRepository groupRepository) : base(groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Result<List<LearnerGroup>> GetByCourse(int courseId)
    {
        return _groupRepository.GetCourseGroups(courseId);
    }
}