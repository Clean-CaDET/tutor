using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Interfaces.Learning;
using Xunit;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning;

[Collection("Sequential")]
public class InstructionTests : BaseKnowledgeComponentsIntegrationTest
{
    public InstructionTests(KnowledgeComponentsTestFactory factory) : base(factory) {}

    [Theory]
    [MemberData(nameof(InstructionalItems))]
    public void Retrieves_instructional_events(int knowledgeComponentId, int expectedIEsCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var items = ((OkObjectResult)controller.GetInstructionalItems(knowledgeComponentId).Result)?.Value as List<InstructionalItemDto>;

        items.ShouldNotBeNull();
        items.Count.ShouldBe(expectedIEsCount);
    }

    public static IEnumerable<object[]> InstructionalItems()
    {
        return new List<object[]>
        {
            new object[]
            {
                -11,
                2
            },
            new object[]
            {
                -15,
                2
            }
        };
    }

    private static InstructionController CreateController(IServiceScope scope, string id)
    {
        return new InstructionController(scope.ServiceProvider.GetRequiredService<IInstructionService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}