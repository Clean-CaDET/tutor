namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IImageRepository
{
    CourseImage? Get(int id);
    List<CourseImage> GetByCourse(int courseId);
    CourseImage Create(CourseImage image);
    void Delete(CourseImage image);
}