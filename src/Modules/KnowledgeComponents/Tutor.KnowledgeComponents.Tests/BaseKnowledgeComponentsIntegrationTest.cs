using Shouldly;
using Tutor.BuildingBlocks.Tests;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests;

public class BaseKnowledgeComponentsIntegrationTest : BaseWebIntegrationTest<KnowledgeComponentsTestFactory>
{
    public BaseKnowledgeComponentsIntegrationTest(KnowledgeComponentsTestFactory factory) : base(factory) { }

    protected void VerifyEventGenerated(KnowledgeComponentsContext dbContext, string eventType)
    {
        var generatedEvent = dbContext.Events.OrderBy(e => e.TimeStamp).LastOrDefault();
        generatedEvent.ShouldNotBeNull();
        generatedEvent.TimeStamp.ShouldBeInRange(DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow);
        generatedEvent.DomainEvent.RootElement.GetProperty("$discriminator").GetString().ShouldBe(eventType);
    }
}