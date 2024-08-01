using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class CourseImage : Entity
{
    public int CourseId { get; private set; }
    public string Name { get; private set; }
    public string FilePath { get; private set; }
    public string RelativeUrl { get; private set; }

    private CourseImage() {}
    public CourseImage(int courseId, string name, string filePath, string relativeUrl)
    {
        CourseId = courseId;
        Name = name;
        FilePath = filePath;
        RelativeUrl = relativeUrl;
    }
}