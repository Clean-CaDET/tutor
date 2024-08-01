using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class ImageDatabaseRepository : CrudDatabaseRepository<CourseImage, CoursesContext>, IImageRepository
{
    public ImageDatabaseRepository(CoursesContext dbContext) : base(dbContext) {}
    public List<CourseImage> GetByCourse(int courseId)
    {
        return DbContext.CourseImages.Where(i => i.CourseId == courseId).ToList();
    }
}