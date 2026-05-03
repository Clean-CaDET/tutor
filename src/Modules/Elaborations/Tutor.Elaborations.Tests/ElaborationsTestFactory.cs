using System.Runtime.CompilerServices;
using System.Text;
using FluentResults;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.BuildingBlocks.Tests;
using Tutor.Courses.Infrastructure.Database;
using Tutor.Elaborations.Infrastructure.Database;

namespace Tutor.Elaborations.Tests;

public class ElaborationsTestFactory : BaseTestFactory<ElaborationsContext>
{
    public Mock<IAiChatService> MockChatService { get; } = new();

    protected override Type[] GetRequiredDbContextTypes() =>
        [typeof(CoursesContext), typeof(ElaborationsContext)];

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureTestServices(services =>
        {
            var descriptors = services.Where(d => d.ServiceType == typeof(IAiChatService)).ToList();
            foreach (var descriptor in descriptors) services.Remove(descriptor);
            services.AddSingleton<IAiChatService>(MockChatService.Object);
        });
    }

    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ElaborationsContext>));
        services.Remove(descriptor!);
        services.AddDbContext<ElaborationsContext>(SetupTestContext());

        descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CoursesContext>));
        services.Remove(descriptor!);
        services.AddDbContext<CoursesContext>(SetupTestContext());

        return services;
    }

    public void SetupEvaluationMock(
        List<(string key, string type, int grade)> assessments,
        List<string>? misconceptionsTriggeredKeys = null,
        string intent = "Substantive")
    {
        SetupIntentMock(intent);

        if (intent != "Substantive") return;

        var scorerJson = BuildSubstantiveEvalJson(assessments, misconceptionsTriggeredKeys ?? []);
        MockChatService.Setup(x => x.CompleteAsync(
                It.Is<CompletionRequest>(r => r.MaxTokens == 1024), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok(new CompletionResponse
            {
                Content = scorerJson,
                Usage = new TokenUsage(100, 50)
            }));
    }

    public void SetupIntentMock(string intent = "Substantive")
    {
        MockChatService.Setup(x => x.CompleteAsync(
                It.Is<CompletionRequest>(r => r.MaxTokens == 64), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok(new CompletionResponse
            {
                Content = $$"""{ "intent": "{{intent}}" }""",
                Usage = new TokenUsage(30, 5)
            }));
    }

    private static string BuildSubstantiveEvalJson(
        List<(string key, string type, int grade)> assessments,
        List<string> misconceptions)
    {
        var sb = new StringBuilder();
        sb.Append("{ \"assessments\": [");
        sb.Append(string.Join(", ", assessments.Select(a =>
            $"{{ \"key\": \"{a.key}\", \"type\": \"{a.type}\", \"grade\": {a.grade} }}")));
        sb.Append("], \"misconceptionsTriggeredKeys\": [");
        sb.Append(string.Join(", ", misconceptions.Select(m => $"\"{m}\"")));
        sb.Append("]}");
        return sb.ToString();
    }

    public void SetupDialogueMock(params string[] tokens)
    {
        var mockTokens = tokens.Length > 0 ? tokens : ["Mock ", "response."];
        MockChatService.Setup(x => x.StreamAsync(
                It.IsAny<CompletionRequest>(), It.IsAny<CancellationToken>()))
            .Returns(MockStream(mockTokens));
    }

    public void SetupSummaryMock(string summary = "Test summary of the conversation.")
    {
        MockChatService.Setup(x => x.StreamAsync(
                It.Is<CompletionRequest>(r => r.MaxTokens == 256 && r.Temperature == 0.5),
                It.IsAny<CancellationToken>()))
            .Returns(MockStream([summary]));
    }

    private static async IAsyncEnumerable<string> MockStream(
        string[] tokens, [EnumeratorCancellation] CancellationToken ct = default)
    {
        foreach (var token in tokens)
        {
            await Task.Yield();
            yield return token;
        }
    }
}
