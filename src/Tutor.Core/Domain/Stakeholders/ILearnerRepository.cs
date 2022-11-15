using System.Collections.Generic;

namespace Tutor.Core.Domain.Stakeholders
{
    public interface ILearnerRepository
    {
        Learner GetByUserId(int userId);
        Learner GetByIndex(string index);
        List<Learner> GetByGroupId(int groupId);
    }
}
