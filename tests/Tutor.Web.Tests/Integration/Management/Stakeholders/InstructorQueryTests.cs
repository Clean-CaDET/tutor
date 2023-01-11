using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Controllers.Administrators.Stakeholders;
using Tutor.Web.Mappings.Stakeholders;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Stakeholders;

[Collection("Sequential")]
public class InstructorQueryTests : BaseWebIntegrationTest
{
    public InstructorQueryTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Retrieves_instructors()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope);

        var result = ((OkObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<StakeholderAccountDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(2);
        result.TotalCount.ShouldBe(2);
    }

    private InstructorController SetupInstructorController(IServiceScope scope)
    {
        return new InstructorController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IInstructorService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}