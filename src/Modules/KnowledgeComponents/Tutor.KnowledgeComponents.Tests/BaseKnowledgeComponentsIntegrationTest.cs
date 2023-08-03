using Tutor.BuildingBlocks.Tests;

namespace Tutor.KnowledgeComponents.Tests;

public class BaseKnowledgeComponentsIntegrationTest : BaseWebIntegrationTest<KnowledgeComponentsTestFactory>
{
    public BaseKnowledgeComponentsIntegrationTest(KnowledgeComponentsTestFactory factory) : base(factory) { }
}