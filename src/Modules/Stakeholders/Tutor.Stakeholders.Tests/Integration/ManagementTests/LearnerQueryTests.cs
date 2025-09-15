using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Stakeholders;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Public.Management;

namespace Tutor.Stakeholders.Tests.Integration.ManagementTests;

[Collection("Sequential")]
public class LearnerQueryTests : BaseStakeholdersIntegrationTest
{
    public LearnerQueryTests(StakeholdersTestFactory factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(LearnerData))]
    public void Retrieves_learners(string[] indexes, int expectedCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetByIndexes(indexes).Result)?.Value as PagedResult<StakeholderAccountDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(expectedCount);
        result.TotalCount.ShouldBe(expectedCount);
    }

    public static IEnumerable<object[]> LearnerData()
    {
        return new List<object[]>
        {
            new object[]
            {
                new[] { "SU-1-2021" },
                1
            },
            new object[]
            {
                new[] { "SU-1-2021", "SU-2-2021", "SU-3-2021" },
                3
            },
            new object[]
            {
                new[] { "SU-1-2021", "SU-1-2021", "SU-1-2021" },
                1
            },
            new object[]
            {
                new[] { "SU-1-2021", "SU-222-2021" },
                1
            }
        };
    }

    [Fact]
    public void Retrieves_learners_with_bad_argument()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = (ObjectResult)controller.GetByIndexes(Array.Empty<string>()).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(400);
    }

    [Fact]
    public void Retrieves_paged_learners()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<StakeholderAccountDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(10);
        result.TotalCount.ShouldBe(10);
        foreach (var item in result.Results)
        {
            item.ShouldNotBeNull();
            item.LearnerType.ShouldNotBeNull();
        }
    }

    private static LearnerController CreateController(IServiceScope scope)
    {
        return new LearnerController(scope.ServiceProvider.GetRequiredService<ILearnerService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}