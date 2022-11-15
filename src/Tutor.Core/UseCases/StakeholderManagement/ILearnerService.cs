using FluentResults;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.StakeholderManagement
{
    public interface ILearnerService
    {
        Result<Learner> GetLearnerProfile(int id);
    }
}