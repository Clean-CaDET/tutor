using FluentResults;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.BuildingBlocks.AI.Core.Embeddings;
using Tutor.BuildingBlocks.AI.Core.VectorStores;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Authoring;

[Collection("Sequential")]
public class KnowledgeComponentIndexingTests : IClassFixture<KnowledgeComponentsIndexingTestFactory>
{
    protected KnowledgeComponentsIndexingTestFactory Factory { get; }

    public KnowledgeComponentIndexingTests(KnowledgeComponentsIndexingTestFactory factory)
    {
        Factory = factory;
    }

    private Mock<ITextEmbeddingService> CreateMockEmbeddingService()
    {
        return Factory.CreateFreshMock();
    }

    protected static ControllerContext BuildContext(string id, string role)
    {
        return new ControllerContext()
        {
            HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext()
            {
                User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(role + "Id", id)
                }))
            }
        };
    }

    [Fact]
    public async Task Indexes_knowledge_component_instructional_items()
    {
        var mockEmbeddingService = CreateMockEmbeddingService();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var vectorStore = scope.ServiceProvider.GetRequiredService<IVectorStore<InstructionalItemEmbeddingMetadata>>();

        // Setup: KC -10 has 2 text items (Markdown) and 1 image - only text items should be indexed
        var mockEmbeddings = new List<EmbeddingResponse>
        {
            new(CreateMockVector(1536), 10),
            new(CreateMockVector(1536), 10)
        };

        mockEmbeddingService
            .Setup(x => x.GenerateEmbeddingsAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok<IReadOnlyList<EmbeddingResponse>>(mockEmbeddings));

        dbContext.Database.BeginTransaction();

        var result = await controller.Index(-10, CancellationToken.None);

        dbContext.ChangeTracker.Clear();

        result.ShouldBeOfType<OkResult>();

        // Verify embeddings were generated for the 2 text items
        mockEmbeddingService.Verify(
            x => x.GenerateEmbeddingsAsync(
                It.Is<IEnumerable<string>>(texts => texts.Count() == 2),
                It.IsAny<CancellationToken>()),
            Times.Once);

        // Verify vectors were stored in the vector database
        var searchQuery = new VectorSearchQuery
        {
            QueryEmbedding = CreateMockVector(1536),
            TopK = 10
        };
        var searchResult = await vectorStore.SearchAsync(searchQuery, CancellationToken.None);
        searchResult.IsSuccess.ShouldBeTrue();
        var storedVectors = searchResult.Value.Where(v => v.Record.Metadata.KnowledgeComponentId == -10).ToList();
        storedVectors.Count.ShouldBe(2);
        storedVectors[0].Record.Metadata.InstructionalItemId.ShouldBe(-101);
        storedVectors[1].Record.Metadata.InstructionalItemId.ShouldBe(-102);
    }

    [Fact]
    public async Task Deindexes_knowledge_component_instructional_items()
    {
        var mockEmbeddingService = CreateMockEmbeddingService();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var vectorStore = scope.ServiceProvider.GetRequiredService<IVectorStore<InstructionalItemEmbeddingMetadata>>();

        // Setup: First index KC -11 (has 1 text item)
        var mockEmbedding = new List<EmbeddingResponse>
        {
            new(CreateMockVector(1536), 10)
        };

        mockEmbeddingService
            .Setup(x => x.GenerateEmbeddingsAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok<IReadOnlyList<EmbeddingResponse>>(mockEmbedding));

        dbContext.Database.BeginTransaction();
        await controller.Index(-11, CancellationToken.None);

        // Verify the vector was stored
        var searchQueryBefore = new VectorSearchQuery
        {
            QueryEmbedding = CreateMockVector(1536),
            TopK = 10
        };
        var searchBeforeDelete = await vectorStore.SearchAsync(searchQueryBefore, CancellationToken.None);
        searchBeforeDelete.IsSuccess.ShouldBeTrue();
        var vectorsBeforeDelete = searchBeforeDelete.Value.Where(v => v.Record.Metadata.KnowledgeComponentId == -11).ToList();
        vectorsBeforeDelete.Count.ShouldBe(1);

        // Act: Deindex
        var result = await controller.Deindex(-11, CancellationToken.None);

        dbContext.ChangeTracker.Clear();
        // Assert
        result.ShouldBeOfType<OkResult>();

        // Verify vectors were removed from the vector database
        var searchQueryAfter = new VectorSearchQuery
        {
            QueryEmbedding = CreateMockVector(1536),
            TopK = 10
        };
        var searchAfterDelete = await vectorStore.SearchAsync(searchQueryAfter, CancellationToken.None);
        searchAfterDelete.IsSuccess.ShouldBeTrue();
        var vectorsAfterDelete = searchAfterDelete.Value.Where(v => v.Record.Metadata.KnowledgeComponentId == -11).ToList();
        vectorsAfterDelete.Count.ShouldBe(0);
    }

    [Fact]
    public async Task Rejects_indexing_for_non_owner_instructor()
    {
        using var scope = Factory.Services.CreateScope();
        // Use a different instructor ID that doesn't own KC -10
        var controller = CreateController(scope, "-999");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();

        dbContext.Database.BeginTransaction();

        var result = await controller.Index(-10, CancellationToken.None);

        dbContext.ChangeTracker.Clear();

        result.ShouldBeOfType<ObjectResult>();
        var objectResult = (ObjectResult)result;
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public async Task Handles_kc_with_no_text_items()
    {
        var mockEmbeddingService = CreateMockEmbeddingService();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();

        // KC -41 has no instructional items
        dbContext.Database.BeginTransaction();

        var result = await controller.Index(-41, CancellationToken.None);

        dbContext.ChangeTracker.Clear();
        // Should succeed without attempting to generate embeddings
        result.ShouldBeOfType<OkResult>();
        mockEmbeddingService.Verify(
            x => x.GenerateEmbeddingsAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task Handles_embedding_service_failure()
    {
        var mockEmbeddingService = CreateMockEmbeddingService();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();

        mockEmbeddingService
            .Setup(x => x.GenerateEmbeddingsAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Fail("Embedding service error"));

        dbContext.Database.BeginTransaction();

        var result = await controller.Index(-10, CancellationToken.None);

        dbContext.ChangeTracker.Clear();
        result.ShouldBeOfType<ObjectResult>();
        var objectResult = (ObjectResult)result;
        objectResult.StatusCode.ShouldBe(500);
    }

    private static KnowledgeComponentIndexingController CreateController(IServiceScope scope, string instructorId = "-51")
    {
        return new KnowledgeComponentIndexingController(scope.ServiceProvider.GetRequiredService<IKnowledgeComponentIndexingService>())
        {
            ControllerContext = BuildContext(instructorId, "instructor")
        };
    }

    private static ReadOnlyMemory<float> CreateMockVector(int dimensions)
    {
        var vector = new float[dimensions];
        var random = new Random(42); // Fixed seed for consistent tests
        for (int i = 0; i < dimensions; i++)
        {
            vector[i] = (float)random.NextDouble();
        }
        return new ReadOnlyMemory<float>(vector);
    }
}

/// <summary>
/// Custom test factory that provides a mocked ITextEmbeddingService while using the real vector database.
/// </summary>
public class KnowledgeComponentsIndexingTestFactory : KnowledgeComponentsTestFactory
{
    private readonly Mock<ITextEmbeddingService> _mockEmbeddingService = new();

    public Mock<ITextEmbeddingService> CreateFreshMock()
    {
        _mockEmbeddingService.Reset();
        return _mockEmbeddingService;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Replace ITextEmbeddingService with our mock
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(ITextEmbeddingService));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
            services.AddSingleton(_mockEmbeddingService.Object);
        });

        base.ConfigureWebHost(builder);
    }
}
