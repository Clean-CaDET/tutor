using Tutor.BuildingBlocks.Tests;

namespace Tutor.LanguageModel.Tests;

public class BaseLanguageModelIntegrationTest : BaseWebIntegrationTest<LanguageModelTestFactory>
{
    public BaseLanguageModelIntegrationTest(LanguageModelTestFactory factory) : base(factory) {}
}
