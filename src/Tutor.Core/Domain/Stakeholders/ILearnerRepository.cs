using System.Collections.Generic;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Core.Domain.Stakeholders
{
    public interface ILearnerRepository
    {
        Learner GetByUserId(int userId);
        Learner GetByIndex(string index);
        List<Learner> GetByGroupId(int groupId);
        Learner Save(Learner learner);
        Task<PagedResult<Learner>> GetLearnersWithMasteriesAsync(int page, int pageSize, int groupId, int courseId);
        List<LearnerGroup> GetGroups();
        int CountEnrolledInUnit(int unitId, List<int> learnerIds);
    }
}
