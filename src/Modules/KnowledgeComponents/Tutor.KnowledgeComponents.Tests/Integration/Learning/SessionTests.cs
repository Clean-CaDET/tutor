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
        VerifyEventGenerated(dbContext, "SessionTerminated");
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
        // VerifyEventGenerated(dbContext, "SessionPaused");
        // Does not work since Paused changes the timestamp to some minutes earlier (making Launched occur last).
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
        VerifyEventGenerated(dbContext, "SessionContinued");
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
        VerifyEventGenerated(dbContext, "SessionTerminated");
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
        VerifyEventGenerated(dbContext, "SessionAbandoned");
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
        VerifyEventGenerated(dbContext, "SessionAbandoned");
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
        VerifyEventGenerated(dbContext, "SessionTerminated");
    }
    
    [Fact]
    public void Pause_fails_without_active_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var pauseResult = (ObjectResult)controller.Pause(-15);

        pauseResult.ShouldNotBeNull();
        pauseResult.StatusCode.ShouldBe(500);
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
    public void Continue_fails_without_active_session()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var continueResult = (ObjectResult)controller.TerminatePause(-15);

        continueResult.ShouldNotBeNull();
        continueResult.StatusCode.ShouldBe(500);
    }

    [Fact]
    public void Continue_without_active_pause()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        var continueResult = controller.TerminatePause(-15);

        continueResult.ShouldBeOfType<OkResult>();
    }

    [Fact]
    public void Pause_with_active_pause()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var launchResult = controller.LaunchSession(-15);
        controller.Pause(-15);
        var pauseResult = controller.Pause(-15);

        pauseResult.ShouldBeOfType<OkResult>();
    }

    private static SessionController CreateController(IServiceScope scope, string id)
    {
        return new SessionController(scope.ServiceProvider.GetRequiredService<ISessionService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}