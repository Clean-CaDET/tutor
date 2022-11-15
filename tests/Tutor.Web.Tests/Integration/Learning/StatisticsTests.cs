using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.UseCases.Learning;
using Tutor.Web.Controllers.Learners.Learning;
using Tutor.Web.Mappings.Mastery;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning
{
    [Collection("Sequential")]
    public class StatisticsTests : BaseWebIntegrationTest
    {
        public StatisticsTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Fact]
        public void Retrieves_kcm_statistics()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupStatisticsController(scope, "-2");

            var kcMasteryStatistics = ((OkObjectResult)controller.GetKcMasteryStatistics(-15).Result).Value as KcMasteryStatisticsDto;

            kcMasteryStatistics.ShouldNotBeNull();
            kcMasteryStatistics.IsSatisfied.ShouldBe(false);
            kcMasteryStatistics.Mastery.ShouldBe(0.5);
            kcMasteryStatistics.TotalCount.ShouldBe(4);
            kcMasteryStatistics.AttemptedCount.ShouldBe(4);
            kcMasteryStatistics.PassedCount.ShouldBe(0);
        }

        private LearningStatisticsController SetupStatisticsController(IServiceScope scope, string id)
        {
            return new LearningStatisticsController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IStatisticsService>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
        }
    }
}