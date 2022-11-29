using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Knowledge;

public interface ICourseService
{
    Result<List<Course>> GetAll(bool includeArchived);
    Result<Course> Create(Course course);
    Result Update(Course course);
    Result Delete(int id);
}