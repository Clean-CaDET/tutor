using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Authoring;

[Collection("Sequential")]
public class ReflectionTests : BaseCoursesIntegrationTest
{
    public ReflectionTests(CoursesTestFactory factory) : base(factory) { }

    [Theory]
    [InlineData("-52", -1, 0, 0)]
    [InlineData("-52", -2, 1, 5)]
    [InlineData("-52", -3, 1, 3)]
    public void Gets_reflections_for_unit(string instructorId, int unitId, int expectedReflectionCount, int expectedQuestionCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetByUnit(unitId).Result!).Value as List<ReflectionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedReflectionCount);
        var questions = result.SelectMany(r => r.Questions).ToList();
        questions.Count.ShouldBe(expectedQuestionCount);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-52");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var newEntity = CreateReflection();
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(-1, newEntity).Result)?.Value as ReflectionDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(newEntity.Name);
        result.Questions.Count.ShouldBe(newEntity.Questions.Count);

        var storedEntity = dbContext.Reflections.Include(reflection => reflection.Questions).FirstOrDefault(i => i.Name == newEntity.Name);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
        storedEntity.Name.ShouldBe(result.Name);
        storedEntity.Questions.Count.ShouldBe(result.Questions.Count);
    }

    private static ReflectionDto CreateReflection()
    {
        return new ReflectionDto
        {
            Name = "Test",
            Order = 1,
            Questions = new List<ReflectionQuestionDto>
            {
                new()
                {
                    Order = 1,
                    Type = ReflectionQuestionType.OpenEnded,
                    Text = "Test 1"
                },
                new()
                {
                    Order = 2,
                    Type = ReflectionQuestionType.OpenEnded,
                    Text = "Test 2"
                }
            }
        };
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-52");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var updatedEntity = CreateUpdatedReflection();
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(-1, updatedEntity).Result)?.Value as ReflectionDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(updatedEntity.Name);
        result.Questions.Count.ShouldBe(updatedEntity.Questions.Count);

        var storedEntity = dbContext.Reflections.Include(reflection => reflection.Questions).FirstOrDefault(i => i.Name == updatedEntity.Name);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
        storedEntity.Name.ShouldBe(result.Name);
        storedEntity.Questions.Count.ShouldBe(result.Questions.Count);
    }

    private static ReflectionDto CreateUpdatedReflection()
    {
        return new ReflectionDto
        {
            Id = -1,
            Name = "Changed name 1",
            Questions = new List<ReflectionQuestionDto>
            {
                new()
                {
                    Id = -1,
                    Order = 1,
                    Type = ReflectionQuestionType.OpenEnded,
                    Text = "Changed q 1"
                },
                new()
                {
                    Id = -2,
                    Order = 2,
                    Type = ReflectionQuestionType.OpenEnded,
                    Text = "Changed q 2"
                }
            }
        };
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-52");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-2);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.Reflections.FirstOrDefault(i => i.Id == -2);
        storedEntity.ShouldBeNull();
        var storedQuestions = dbContext.ReflectionQuestions.Where(q => q.ReflectionId == -2).ToList();
        storedQuestions.Count.ShouldBe(0);
    }

    private static ReflectionController CreateController(IServiceScope scope, string id)
    {
        return new ReflectionController(scope.ServiceProvider.GetRequiredService<IReflectionAuthoringService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}