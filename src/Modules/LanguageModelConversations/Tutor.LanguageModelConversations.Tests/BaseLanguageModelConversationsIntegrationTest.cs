using Tutor.BuildingBlocks.Tests;

namespace Tutor.LanguageModelConversations.Tests;

public class BaseLanguageModelConversationsIntegrationTest : BaseWebIntegrationTest<LanguageModelConversationsTestFactory>
{
    public BaseLanguageModelConversationsIntegrationTest(LanguageModelConversationsTestFactory factory) : base(factory) {}
}
