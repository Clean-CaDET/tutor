using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.UseCases;

namespace Tutor.Courses.Infrastructure.Database;

public class CoursesUnitOfWork : UnitOfWork<CoursesContext>, ICoursesUnitOfWork
{
    public CoursesUnitOfWork(CoursesContext dbContext) : base(dbContext) {}
}