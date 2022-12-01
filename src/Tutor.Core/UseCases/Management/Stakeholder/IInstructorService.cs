using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholder;

public interface IInstructorService
{
    Result<List<Instructor>> GetAll();
    Result<Instructor> Get(int id);
    Result<Instructor> Create(Instructor entity);
    Result Update(Instructor entity);
    Result Delete(int id);
}