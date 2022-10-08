using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Web.Mappings.Analytics;
using Xunit;

namespace Tutor.Web.Tests.Integration.Analytics;

[Collection("Sequential")]
public class LearnerProgressTests : BaseWebIntegrationTest
{
    public LearnerProgressTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Retrieves_knowledge_component_statistics(string userId, int groupId, int courseId, PagedResult<LearnerProgressDto> expectedProgress)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateAnalyticsController(scope, userId);

        var result = ((OkObjectResult)controller.GetProgress(1, 10, groupId, courseId).Result).Value as PagedResult<LearnerProgressDto>;

        result.ShouldNotBeNull();
        result.TotalCount.ShouldBe(expectedProgress.TotalCount);
    }

    public static IEnumerable<object[]> TestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                "-50", -1, -1,
                new PagedResult<LearnerProgressDto>(new List<LearnerProgressDto>(), 5)
            },
            new object[]
            {
                "-51", 0, -1,
                new PagedResult<LearnerProgressDto>(new List<LearnerProgressDto>(), 5)
            }
        };
    }
}
