using Microsoft.Extensions.DependencyInjection;
using Tutor.API.Controllers.Learner.Learning.Assessment;
using Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

public class BaseAssessmentEvaluationIntegrationTest : BaseKnowledgeComponentsIntegrationTest
{
    public BaseAssessmentEvaluationIntegrationTest(KnowledgeComponentsTestFactory factory) : base(factory) { }

    protected EvaluationController CreateController(IServiceScope scope, string id)
    {
        return new EvaluationController(scope.ServiceProvider.GetRequiredService<IEvaluationService>(),
            scope.ServiceProvider.GetRequiredService<IHelpService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}