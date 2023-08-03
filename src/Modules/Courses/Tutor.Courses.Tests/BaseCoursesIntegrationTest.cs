using Tutor.BuildingBlocks.Tests;

namespace Tutor.Courses.Tests;

public class BaseCoursesIntegrationTest : BaseWebIntegrationTest<CoursesTestFactory>
{
    public BaseCoursesIntegrationTest(CoursesTestFactory factory) : base(factory) { }
}