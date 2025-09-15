using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Infrastructure.Database;
using Tutor.KnowledgeComponents.Infrastructure.Database;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class CourseCommandTests : BaseCoursesIntegrationTest
{
    public CourseCommandTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var newEntity = new CourseDto
        {
            Code = "TT-1",
            Name = "Test-1"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(newEntity).Result)?.Value as CourseDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        var storedEntity = dbContext.Courses.FirstOrDefault(i => i.Code == newEntity.Code);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
    }

    [Fact]
    public void Clones()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var kcDbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var tasksDbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var startingKcCount = kcDbContext.KnowledgeComponents.Count();
        var startingReflectionsCount = dbContext.Reflections.Count();
        var startingReflectionQuestionsCount = dbContext.ReflectionQuestions.Count();

        var newCourse = new CourseDto
        {
            Code = "TTT-2",
            Name = "TestCourseClone2",
            StartDate = DateTime.UnixEpoch
        };

        var result = ((OkObjectResult)controller.Clone(-2, newCourse).Result)?.Value as CourseDto;

        dbContext.ChangeTracker.Clear();
        kcDbContext.ChangeTracker.Clear();
        tasksDbContext.ChangeTracker.Clear();

        result.ShouldNotBeNull();
        result.Name.ShouldBe("TestCourseClone2");
        result.Code.ShouldBe("TTT-2");
        result.StartDate.ShouldBe(DateTime.UnixEpoch);
        result.KnowledgeUnits?.Count.ShouldBe(1);
        var clonedCourse = dbContext.Courses.FirstOrDefault(c => c.Id == result.Id);
        clonedCourse.ShouldNotBeNull();
        var units = dbContext.KnowledgeUnits.Where(u => u.CourseId == result.Id).ToList();
        units.Count.ShouldBe(1);
        var ownerships = dbContext.CourseOwnerships.Where(o => o.Course.Id == result.Id).ToList();
        ownerships.Count.ShouldBe(1);
        var endingKcCount = kcDbContext.KnowledgeComponents.Count();
        endingKcCount.ShouldBe(startingKcCount + 2);
        int unitId = units[0].Id;
        var tasks = tasksDbContext.LearningTasks.Where(l => l.UnitId == unitId)
            .Include(l => l.Steps!).ThenInclude(s => s.Standards).ToList();
        AssertTaskCorrectlyCloned(tasks);
        
        var endingReflectionsCount = dbContext.Reflections.Count();
        var endingReflectionQuestionsCount = dbContext.ReflectionQuestions.Count();
        endingReflectionsCount.ShouldBe(startingReflectionsCount + 1);
        endingReflectionQuestionsCount.ShouldBe(startingReflectionQuestionsCount + 3);
    }

    private static void AssertTaskCorrectlyCloned(List<LearningTask> tasks)
    {
        tasks.ShouldNotBeNull();
        tasks.Count.ShouldBe(1);
        tasks[0].Name.ShouldBe("FifthTask");
        tasks[0].MaxPoints.ShouldBe(10);
        tasks[0].Steps.ShouldNotBeNull();
        tasks[0].Steps?.Count.ShouldBe(2);
        tasks[0].Steps?[1].Code.ShouldBe("U3-LT5-A1");
        tasks[0].Steps?[0].Code.ShouldBe("U3-LT5-A11");
        var parentId = tasks[0].Steps?[1].Id ?? 0;
        tasks[0].Steps?[0].ParentId.ShouldBe(parentId);
        tasks[0].Steps?[1].Standards?.Count.ShouldBe(1);
        tasks[0].Steps?[0].Standards?.Count.ShouldBe(1);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var updatedEntity = new CourseDto
        {
            Id = -1,
            Code = "TT-2",
            Name = "Test-2",
            Description = "Test-2"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as CourseDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Code.ShouldBe(updatedEntity.Code);
        result.Name.ShouldBe(updatedEntity.Name);
        result.Description.ShouldBe(updatedEntity.Description);
        var updatedCourse = dbContext.Courses.FirstOrDefault(i => i.Code == "TT-2");
        updatedCourse.ShouldNotBeNull();
        var oldCourse = dbContext.Courses.FirstOrDefault(i => i.Code == "T-1");
        oldCourse.ShouldBeNull();
    }

    [Fact]
    public void Update_fails_invalid_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var updatedEntity = new CourseDto
        {
            Id = -1000
        };

        var result = (ObjectResult)controller.Update(updatedEntity).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Archives()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Archive(-1, true).Result)?.Value as CourseDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.IsArchived.ShouldBe(true);
        var storedCourse = dbContext.Courses.Include(c => c.KnowledgeUnits).FirstOrDefault(i => i.Id == -1);
        storedCourse.ShouldNotBeNull();
        storedCourse.IsArchived.ShouldBe(true);
        var units = storedCourse.KnowledgeUnits.Select(u => u.Id);
        var enrollments = dbContext.UnitEnrollments.Where(e => units.Contains(e.KnowledgeUnit.Id)).ToList();
        enrollments.ShouldNotBeNull();
        enrollments.All(e => e.Status == EnrollmentStatus.Deactivated).ShouldBeTrue();
    }

    [Fact]
    public void Deletes_empty_course()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-3);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -3);
        storedCourse.ShouldBeNull();
    }

    [Fact]
    public void Deletes_course_with_ownerships()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-4);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -4);
        storedCourse.ShouldBeNull();
        var storedOwnerships = dbContext.CourseOwnerships.Where(co => co.Course.Id == -4);
        storedOwnerships.Count().ShouldBe(0);
    }

    [Fact]
    public void Delete_fails_invalid_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = (ObjectResult)controller.Delete(-1000);

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Delete_fails_existing_units()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();

        var result = (ObjectResult)controller.Delete(-1);

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -1);
        storedCourse.ShouldNotBeNull();
    }

    private static CourseController CreateController(IServiceScope scope)
    {
        return new CourseController(scope.ServiceProvider.GetRequiredService<ICourseService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}