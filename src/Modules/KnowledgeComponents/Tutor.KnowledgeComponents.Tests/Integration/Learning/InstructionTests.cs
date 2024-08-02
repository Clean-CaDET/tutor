using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning;

[Collection("Sequential")]
public class InstructionTests : BaseKnowledgeComponentsIntegrationTest
{
    public InstructionTests(KnowledgeComponentsTestFactory factory) : base(factory) {}

    [Theory]
    [MemberData(nameof(InstructionalItems))]
    public void Retrieves_instructional_items(int knowledgeComponentId, int expectedIEsCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();

        var items = ((OkObjectResult)controller.GetInstructionalItems(knowledgeComponentId, "D1").Result)?.Value as List<InstructionalItemDto>;

        items.ShouldNotBeNull();
        items.Count.ShouldBe(expectedIEsCount);
        VerifyEventGenerated(dbContext, "InstructionalItemsSelected");
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