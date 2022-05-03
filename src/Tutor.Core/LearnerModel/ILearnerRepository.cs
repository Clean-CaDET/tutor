using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerRepository
    {
        Learner GetByUserId(int userId);
        Learner GetByIndex(string index);
        Learner Save(Learner learner);
        Task<PagedResult<Learner>> GetLearnersWithMasteriesAsync(int page, int pageSize);
    }
}
