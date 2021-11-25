using Xunit;

namespace Tutor.Web.Tests.Integration
{
    public class BaseIntegrationTest : IClassFixture<TutorApplicationTestFactory<Startup>>
    {
        protected readonly TutorApplicationTestFactory<Startup> Factory;

        public BaseIntegrationTest(TutorApplicationTestFactory<Startup> factory)
        {
            Factory = factory;
        }
    }
}
