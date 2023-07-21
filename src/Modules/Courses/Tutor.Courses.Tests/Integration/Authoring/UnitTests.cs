using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Authoring;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Authoring;

[Collection("Sequential")]
public class UnitTests : BaseCoursesIntegrationTest
{
    public UnitTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var newEntity = new KnowledgeUnitDto
        {
            Code = "TT-5",
            Name = "TT-5"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(-1, newEntity).Result)?.Value as KnowledgeUnitDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        var storedEntity = dbContext.KnowledgeUnits.FirstOrDefault(i => i.Code == newEntity.Code);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var updatedEntity = new KnowledgeUnitDto
        {
            Id = -1,
            Code = "TT-1",
            Name = "TT-1"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(-1, updatedEntity).Result)?.Value as KnowledgeUnitDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Code.ShouldBe(updatedEntity.Code);
        var savedEntity = dbContext.KnowledgeUnits.FirstOrDefault(i => i.Code == "TT-1");
        savedEntity.ShouldNotBeNull();
        var oldEntity = dbContext.KnowledgeUnits.FirstOrDefault(i => i.Code == "T-1");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-4);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.KnowledgeUnits.FirstOrDefault(i => i.Id == -4);
        storedEntity.ShouldBeNull();
    }

    private static UnitController CreateController(IServiceScope scope)
    {
        return new UnitController(scope.ServiceProvider.GetRequiredService<IUnitService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}