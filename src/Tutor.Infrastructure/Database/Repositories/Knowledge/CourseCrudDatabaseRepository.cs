using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

public class CourseCrudDatabaseRepository : CrudDatabaseRepository<Course>, ICrudCourseRepository
{
    public CourseCrudDatabaseRepository(TutorContext dbContext) : base(dbContext) {}

    public List<Course> GetActive()
    {
        return DbContext.Courses.Where(c => !c.IsArchived).ToList();
    }
}