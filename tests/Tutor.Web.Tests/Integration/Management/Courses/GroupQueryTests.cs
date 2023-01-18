using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.UseCases.Management.Enrollments;
using Tutor.Web.Controllers.Administrators.Courses;
using Tutor.Web.Mappings.Enrollments;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Courses;

[Collection("Sequential")]
public class GroupQueryTests : BaseWebIntegrationTest
{
    public GroupQueryTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Gets_all()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);

        var result = ((OkObjectResult)controller.GetAll(-1).Result)?.Value as PagedResult<GroupDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(3);
        result.TotalCount.ShouldBe(3);
    }

    private GroupController SetupController(IServiceScope scope)
    {
        return new GroupController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ILearnerGroupService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}