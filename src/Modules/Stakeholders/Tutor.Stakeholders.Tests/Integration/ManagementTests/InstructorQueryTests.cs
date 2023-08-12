using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Stakeholders;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Public.Management;

namespace Tutor.Stakeholders.Tests.Integration.ManagementTests;

[Collection("Sequential")]
public class InstructorQueryTests : BaseStakeholdersIntegrationTest
{
    public InstructorQueryTests(StakeholdersTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_instructors()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<StakeholderAccountDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(2);
        result.TotalCount.ShouldBe(2);
    }

    private static InstructorController CreateController(IServiceScope scope)
    {
        return new InstructorController(scope.ServiceProvider.GetRequiredService<IInstructorService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}