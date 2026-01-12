using FluentResults;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.BuildingBlocks.AI.Core.Embeddings;
using Tutor.BuildingBlocks.AI.Core.VectorStores;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Authoring;

[Collection("Sequential")]
public class KnowledgeComponentIndexingTests : IClassFixture<KnowledgeComponentsIndexingTestFactory>
{
    private readonly KnowledgeComponentsIndexingTestFactory _factory;

    public KnowledgeComponentIndexingTests(KnowledgeComponentsIndexingTestFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Indexes_knowledge_component_with_text_items()
    {
        // Arrange
        var mockEmbeddingService = _factory.CreateFreshMock();
        var mockEmbeddings = new List<EmbeddingResponse>
        {
            new(CreateMockVector(1536), 10),
            new(CreateMockVector(1536), 10)
        };
        mockEmbeddingService
            .Setup(x => x.GenerateEmbeddingsAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok<IReadOnlyList<EmbeddingResponse>>(mockEmbeddings));

        using var scope = _factory.Services.CreateScope();
        var controller = CreateIndexingController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var vectorStore = scope.ServiceProvider.GetRequiredService<IVectorStore<InstructionalItemEmbeddingMetadata>>();
        dbContext.Database.BeginTransaction();

        // Act - KC -10 has 2 text items and 1 image (from b-kc-ii.sql)
        var result = await controller.Index(-10, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<OkResult>();

        mockEmbeddingService.Verify(
            x => x.GenerateEmbeddingsAsync(It.Is<IEnumerable<string>>(texts => texts.Count() == 2), It.IsAny<CancellationToken>()),
            Times.Once);

        dbContext.ChangeTracker.Clear();
        var kc = dbContext.KnowledgeComponents.First(k => k.Id == -10);
        kc.IndexingDegree.ShouldBe(KcIndexingDegree.Full);

        var searchQuery = new VectorSearchQuery { QueryEmbedding = CreateMockVector(1536), TopK = 10 };
        var searchResult = await vectorStore.SearchAsync(searchQuery, CancellationToken.None);
        searchResult.IsSuccess.ShouldBeTrue();
        var storedVectors = searchResult.Value.Where(v => v.Record.Metadata.KnowledgeComponentId == -10).ToList();
        storedVectors.Count.ShouldBe(2);
    }

    [Fact]
    public async Task Deindexes_knowledge_component()
    {
        // Arrange - KC -31 is pre-indexed with vector in b2-kc-indexed.sql
        _factory.CreateFreshMock();

        using var scope = _factory.Services.CreateScope();
        var controller = CreateIndexingController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var vectorStore = scope.ServiceProvider.GetRequiredService<IVectorStore<InstructionalItemEmbeddingMetadata>>();
        dbContext.Database.BeginTransaction();

        // Act
        var result = await controller.Deindex(-31, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<OkResult>();

        dbContext.ChangeTracker.Clear();
        var kc = dbContext.KnowledgeComponents.First(k => k.Id == -31);
        kc.IndexingDegree.ShouldBe(KcIndexingDegree.None);

        var searchQuery = new VectorSearchQuery { QueryEmbedding = CreateMockVector(1536), TopK = 10 };
        var searchResult = await vectorStore.SearchAsync(searchQuery, CancellationToken.None);
        searchResult.IsSuccess.ShouldBeTrue();
        var vectorsAfter = searchResult.Value.Where(v => v.Record.Metadata.KnowledgeComponentId == -31).ToList();
        vectorsAfter.Count.ShouldBe(0);
    }

    [Fact]
    public async Task Rejects_indexing_for_non_owner_instructor()
    {
        // Arrange
        using var scope = _factory.Services.CreateScope();
        var controller = CreateIndexingController(scope, "-999"); // Non-owner instructor
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        // Act
        var result = await controller.Index(-10, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<ObjectResult>();
        var objectResult = (ObjectResult)result;
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public async Task Returns_error_when_embedding_service_fails()
    {
        // Arrange
        var mockEmbeddingService = _factory.CreateFreshMock();
        mockEmbeddingService
            .Setup(x => x.GenerateEmbeddingsAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Fail("Embedding service error"));

        using var scope = _factory.Services.CreateScope();
        var controller = CreateIndexingController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        // Act
        var result = await controller.Index(-10, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<ObjectResult>();
        var objectResult = (ObjectResult)result;
        objectResult.StatusCode.ShouldBe(500);
    }

    [Fact]
    public void Deleting_kc_clears_vector_indexes()
    {
        // Arrange
        _factory.CreateFreshMock();

        using var scope = _factory.Services.CreateScope();
        var controller = CreateKcController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var vectorStore = scope.ServiceProvider.GetRequiredService<IVectorStore<InstructionalItemEmbeddingMetadata>>();
        dbContext.Database.BeginTransaction();

        // Act
        var result = controller.Delete(-31);

        // Assert
        result.ShouldBeOfType<OkResult>();

        var searchQuery = new VectorSearchQuery { QueryEmbedding = CreateMockVector(1536), TopK = 10 };
        var searchResult = vectorStore.SearchAsync(searchQuery, CancellationToken.None).GetAwaiter().GetResult();
        searchResult.IsSuccess.ShouldBeTrue();
        var vectorsAfter = searchResult.Value.Where(v => v.Record.Metadata.KnowledgeComponentId == -31).ToList();
        vectorsAfter.Count.ShouldBe(0);
    }

    [Fact]
    public void Modifying_instructional_item_sets_indexing_degree_to_partial()
    {
        // Arrange - KC -31 is pre-indexed (IndexingDegree=Full) in b2-kc-indexed.sql
        _factory.CreateFreshMock();

        using var scope = _factory.Services.CreateScope();
        var controller = CreateIiController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var iiToUpdate = new TextDto { Id = -311, KnowledgeComponentId = -31, Order = 99, Content = "Updated" };

        // Act
        var result = controller.Update(iiToUpdate);

        // Assert
        result.Result.ShouldBeOfType<OkObjectResult>();

        dbContext.ChangeTracker.Clear();
        var kc = dbContext.KnowledgeComponents.First(k => k.Id == -31);
        kc.IndexingDegree.ShouldBe(KcIndexingDegree.Partial);
    }

    private static KnowledgeComponentIndexingController CreateIndexingController(IServiceScope scope, string instructorId = "-52")
    {
        return new KnowledgeComponentIndexingController(scope.ServiceProvider.GetRequiredService<IKnowledgeComponentIndexingService>())
        {
            ControllerContext = BuildContext(instructorId, "instructor")
        };
    }

    private static KnowledgeComponentController CreateKcController(IServiceScope scope, string instructorId = "-52")
    {
        return new KnowledgeComponentController(scope.ServiceProvider.GetRequiredService<IKnowledgeComponentService>())
        {
            ControllerContext = BuildContext(instructorId, "instructor")
        };
    }

    private static InstructionalItemController CreateIiController(IServiceScope scope, string instructorId = "-52")
    {
        return new InstructionalItemController(scope.ServiceProvider.GetRequiredService<IInstructionalItemsService>())
        {
            ControllerContext = BuildContext(instructorId, "instructor")
        };
    }

    private static ControllerContext BuildContext(string id, string role)
    {
        return new ControllerContext
        {
            HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext
            {
                User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(role + "Id", id)
                }))
            }
        };
    }

    private static ReadOnlyMemory<float> CreateMockVector(int dimensions)
    {
        var vector = new float[dimensions];
        var random = new Random(42);
        for (int i = 0; i < dimensions; i++)
        {
            vector[i] = (float)random.NextDouble();
        }
        return new ReadOnlyMemory<float>(vector);
    }
}

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
