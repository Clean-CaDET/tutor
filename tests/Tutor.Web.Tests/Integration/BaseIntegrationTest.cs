using Xunit;

namespace Tutor.Web.Tests.Integration
{
    public class BaseIntegrationTest : IClassFixture<TutorApplicationTestFactory<Startup>>
    {
        protected TutorApplicationTestFactory<Startup> Factory { get; }

        public BaseIntegrationTest(TutorApplicationTestFactory<Startup> factory)
        {
            Factory = factory;
        }
    }
}
