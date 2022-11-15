using System.Collections.Generic;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Stakeholders
{
    public interface ILearnerRepository
    {
        Learner GetByUserId(int userId);
        Learner GetByIndex(string index);
        List<Learner> GetByGroupId(int groupId);
        Task<PagedResult<Learner>> GetLearnersWithMasteriesAsync(int page, int pageSize, int groupId, int courseId);
    }
}
