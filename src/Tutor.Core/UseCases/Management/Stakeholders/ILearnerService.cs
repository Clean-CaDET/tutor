using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface ILearnerService
{
    Result<List<Learner>> GetAll();
    Result<Learner> Get(int id);
    Result<Learner> Register(Learner learner, string username, string password);
    Result Update(Learner entity);
    Result Delete(int id);
}