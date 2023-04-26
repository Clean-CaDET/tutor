using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Monitoring;

public interface IGroupMonitoringService
{
    Result<PagedResult<LearnerGroup>> GetCourseGroups(int instructorId, int courseId, int page, int pageSize);
    Result<PagedResult<Learner>> GetLearners(int instructorId, int courseId, int groupId, int page, int pageSize);
    Result<List<KnowledgeComponentMastery>> GetLearnerProgress(int unitId, int[] learnerIds, int instructorId);
}