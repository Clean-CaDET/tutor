using Tutor.BuildingBlocks.Tests;

namespace Tutor.LmConversations.Tests;

public class BaseLmConversationsIntegrationTest : BaseWebIntegrationTest<LmConversationsTestFactory>
{
    public BaseLmConversationsIntegrationTest(LmConversationsTestFactory factory) : base(factory) {}
}
