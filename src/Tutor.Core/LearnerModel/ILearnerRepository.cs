using System.Collections.Generic;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerRepository
    {
        Learner GetByUserId(int userId);
        Learner GetByIndex(string index);
        List<Learner> GetByGroupId(int groupId);
        Learner Save(Learner learner);
        Task<PagedResult<Learner>> GetLearnersWithMasteriesAsync(int page, int pageSize, int groupId);
        List<LearnerGroup> GetGroups();
        int CountEnrolledInUnit(int unitId, List<int> learnerIds);
    }
}
