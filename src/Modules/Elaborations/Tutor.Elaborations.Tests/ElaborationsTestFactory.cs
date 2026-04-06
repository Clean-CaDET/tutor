using System.Runtime.CompilerServices;
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

    public void SetupDefaultMocks()
    {
        SetupEvaluationMock();
        SetupDialogueMock();
        SetupSummaryMock();
    }

    public void SetupEvaluationMock(List<int>? propositionsCoveredIds = null,
        List<int>? relationsArticulatedIds = null,
        int? discriminationScore = 2, int? integrationScore = null,
        bool isSubstantive = true)
    {
        var coveredIds = propositionsCoveredIds != null && propositionsCoveredIds.Count > 0
            ? string.Join(",", propositionsCoveredIds)
            : "";
        var articulatedIds = relationsArticulatedIds != null && relationsArticulatedIds.Count > 0
            ? string.Join(",", relationsArticulatedIds)
            : "";
        var discriminationJson = discriminationScore.HasValue ? discriminationScore.Value.ToString() : "null";
        var integrationJson = integrationScore.HasValue ? integrationScore.Value.ToString() : "null";

        var evalJson = $$"""
            {
                "correctnessScore": 2,
                "completenessScore": 2,
                "discriminationScore": {{discriminationJson}},
                "integrationScore": {{integrationJson}},
                "justification": "Good explanation of the concept.",
                "propositionsCoveredIds": [{{coveredIds}}],
                "misconceptionsTriggeredIds": [],
                "relationsArticulatedIds": [{{articulatedIds}}],
                "novelMisconceptions": null,
                "isSubstantive": {{isSubstantive.ToString().ToLower()}}
            }
            """;

        MockChatService.Setup(x => x.CompleteAsync(
                It.Is<CompletionRequest>(r => r.MaxTokens == 1024), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok(new CompletionResponse
            {
                Content = evalJson,
                Usage = new TokenUsage(100, 50)
            }));
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
        MockChatService.Setup(x => x.CompleteAsync(
                It.Is<CompletionRequest>(r => r.MaxTokens == 256), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok(new CompletionResponse
            {
                Content = summary,
                Usage = new TokenUsage(80, 40)
            }));
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
