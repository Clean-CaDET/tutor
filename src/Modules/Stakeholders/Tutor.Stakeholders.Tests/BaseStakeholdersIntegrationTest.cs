using Tutor.BuildingBlocks.Tests;

namespace Tutor.Stakeholders.Tests;

public class BaseStakeholdersIntegrationTest : BaseWebIntegrationTest<StakeholdersTestFactory>
{
    public BaseStakeholdersIntegrationTest(StakeholdersTestFactory factory): base(factory) {}
}