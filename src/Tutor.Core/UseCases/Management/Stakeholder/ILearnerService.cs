using FluentResults;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholder;

public interface ILearnerService
{
    Result<Learner> GetLearnerProfile(int id);
}