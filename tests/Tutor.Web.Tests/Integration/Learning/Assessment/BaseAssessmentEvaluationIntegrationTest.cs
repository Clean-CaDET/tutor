using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Web.Controllers.Learners.Learning.Assessment;

namespace Tutor.Web.Tests.Integration.Learning.Assessment;

public class BaseAssessmentEvaluationIntegrationTest : BaseWebIntegrationTest
{
    public BaseAssessmentEvaluationIntegrationTest(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    protected EvaluationController SetupAssessmentEvaluationController(IServiceScope scope, string id)
    {
        return new EvaluationController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IEvaluationService>(),
            scope.ServiceProvider.GetRequiredService<IHelpService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}