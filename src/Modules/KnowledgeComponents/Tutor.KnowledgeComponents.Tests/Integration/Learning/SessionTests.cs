using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning;

[Collection("Sequential")]
public class SessionTests : BaseKnowledgeComponentsIntegrationTest
{
    public SessionTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Fact]
    public void Launches_and_terminates_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var terminationResult = controller.TerminateSession(-15);

        launchResult.ShouldBeOfType<OkResult>();
        terminationResult.ShouldBeOfType<OkResult>();
    }

    [Fact]
    public void Termination_fails_without_active_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var terminationResult = (ObjectResult)controller.TerminateSession(-15);

        terminationResult.ShouldNotBeNull();
        terminationResult.StatusCode.ShouldBe(500);
    }
    
    [Fact]
    public void Launch_and_pause_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var pauseResult = controller.Pause(-15);

        launchResult.ShouldBeOfType<OkResult>();
        pauseResult.ShouldBeOfType<OkResult>();
    }
    
    [Fact]
    public void Launch_pause_continue_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var pauseResult = controller.Pause(-15);
        var continueResult = controller.TerminatePause(-15);
        
        launchResult.ShouldBeOfType<OkResult>();
        pauseResult.ShouldBeOfType<OkResult>();
        continueResult.ShouldBeOfType<OkResult>();
    }
    
    [Fact]
    public void Launch_pause_continue_terminate_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var pauseResult = controller.Pause(-15);
        var continueResult = controller.TerminatePause(-15);
        var terminateResult = controller.TerminateSession(-15);
        
        launchResult.ShouldBeOfType<OkResult>();
        pauseResult.ShouldBeOfType<OkResult>();
        continueResult.ShouldBeOfType<OkResult>();
        terminateResult.ShouldBeOfType<OkResult>();
    }
    
    [Fact]
    public void Launch_pause_continue_abandon_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var pauseResult = controller.Pause(-15);
        var continueResult = controller.TerminatePause(-15);
        var abandonResult = controller.AbandonSession(-15);
        
        launchResult.ShouldBeOfType<OkResult>();
        pauseResult.ShouldBeOfType<OkResult>();
        continueResult.ShouldBeOfType<OkResult>();
        abandonResult.ShouldBeOfType<OkResult>();
    }
    
    [Fact]
    public void Launch_pause_abandon_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var pauseResult = controller.Pause(-15);
        var abandonResult = controller.AbandonSession(-15);
        
        launchResult.ShouldBeOfType<OkResult>();
        pauseResult.ShouldBeOfType<OkResult>();
        abandonResult.ShouldBeOfType<OkResult>();
    }
    
    [Fact]
    public void Launch_pause_terminate_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var pauseResult = controller.Pause(-15);
        var terminateResult = controller.TerminateSession(-15);
        
        launchResult.ShouldBeOfType<OkResult>();
        pauseResult.ShouldBeOfType<OkResult>();
        terminateResult.ShouldBeOfType<OkResult>();
    }
    
    [Fact]
    public void Pause_without_active_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var pauseResult = controller.Pause(-15);

        pauseResult.ShouldNotBeNull();
        pauseResult.ShouldBeOfType<OkResult>();
    }
    
    [Fact]
    public void Continue_fails_without_active_pause()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var continueResult = (ObjectResult)controller.TerminatePause(-15);

        continueResult.ShouldNotBeNull();
        continueResult.StatusCode.ShouldBe(500);
    }

    private static SessionController CreateController(IServiceScope scope, string id)
    {
        return new SessionController(scope.ServiceProvider.GetRequiredService<ISessionService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}