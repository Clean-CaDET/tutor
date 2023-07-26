using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Monitoring;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces.Monitoring;
using Xunit;

namespace Tutor.KnowledgeComponents.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class GroupMonitoringTests : BaseKnowledgeComponentsIntegrationTest
{
    public GroupMonitoringTests(KnowledgeComponentsTestFactory factory) : base(factory) {}
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Retrieves_learner_progress(string userId, int[] learnerIds, int expectedProgressCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, userId);

        var result = ((OkObjectResult)controller.GetLearnerProgress(-1, learnerIds).Result)?.Value as List<KcmProgressDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedProgressCount);
    }
    
    public static IEnumerable<object[]> TestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                "-51", new []{-2, -3}, 12
            },
            new object[]
            {
                "-51", new []{-2}, 6
            },
            new object[]
            {
                "-51", new []{-3}, 6
            },
            new object[]
            {
                "-51", new []{-1}, 0
            }
        };
    }

    private static LearnerProgressController CreateController(IServiceScope scope, string id)
    {
        return new LearnerProgressController(
            scope.ServiceProvider.GetRequiredService<ILearnerProgressService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}