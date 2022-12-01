using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholder;

public interface ILearnerService
{
    Result<List<Learner>> GetAll();
    Result<Learner> Get(int id);
    Result<Learner> Create(Learner entity);
    Result Update(Learner entity);
    Result Delete(int id);
}