using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface IInstructorService
{
    Result<List<Instructor>> GetAll();
    Result<Instructor> Get(int id);
    Result<Instructor> Register(Instructor instructor, string username, string password);
    Result Update(Instructor entity);
    Result Delete(int id);
}