﻿using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;
using Tutor.KnowledgeComponents.Core.UseCases;
using Tutor.KnowledgeComponents.Core.UseCases.Monitoring;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class MasteryFactoryTests : BaseKnowledgeComponentsIntegrationTest
{
    public MasteryFactoryTests(KnowledgeComponentsTestFactory factory) : base(factory) {}
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Initializes_masteries(int[] learnerIds, int expectedCountIncrement, int expectedAssessmentCountIncrement)
    {
        using var scope = Factory.Services.CreateScope();
        var service = CreateService(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var startingMasteryCount = dbContext.KcMasteries.Count();
        var startingAssessmentMasteryCount = dbContext.KcMasteries.SelectMany(kcm => kcm.AssessmentItemMasteries).Count();
        dbContext.Database.BeginTransaction();

        service.InitializeMasteries(-1, learnerIds);

        dbContext.ChangeTracker.Clear();
        var resultingMasteryCount = dbContext.KcMasteries.Count();
        var resultingAssessmentMasteryCount = dbContext.KcMasteries.SelectMany(kcm => kcm.AssessmentItemMasteries).Count();
        resultingMasteryCount.ShouldBe(startingMasteryCount + expectedCountIncrement);
        resultingAssessmentMasteryCount.ShouldBe(startingAssessmentMasteryCount + expectedAssessmentCountIncrement);
    }
    
    public static IEnumerable<object[]> TestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                new []{-1, -2, -3}, 18, 21
            },
            new object[]
            {
                new []{-2, -3}, 12, 14
            },
            new object[]
            {
                new []{-3}, 6, 7
            }
        };
    }

    private static MasteryFactoryService CreateService(IServiceScope scope)
    {
        return new MasteryFactoryService(
            scope.ServiceProvider.GetRequiredService<IKnowledgeComponentRepository>(),
            scope.ServiceProvider.GetRequiredService<IKnowledgeMasteryRepository>(),
            scope.ServiceProvider.GetRequiredService<IKnowledgeComponentsUnitOfWork>());
    }
}