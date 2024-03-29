﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Analysis;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public.Analysis;

namespace Tutor.KnowledgeComponents.Tests.Integration.Analysis;

[Collection("Sequential")]
public class AssessmentAnalysisTests : BaseKnowledgeComponentsIntegrationTest
{
    public AssessmentAnalysisTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Theory]
    [InlineData("-51", -10)]
    public void Retrieves_ai_statistics(string userId, int kcId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, userId);

        var result = ((OkObjectResult)controller.GetStatistics(kcId).Result).Value as List<AiStatisticsDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
    }

    [Theory]
    [InlineData("-51", -3)]
    public void Retrieves_ai_statistics_fails_instructor_not_course_owner(string userId, int unitId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, userId);

        var result = (ObjectResult)controller.GetStatistics(unitId).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
    }

    private static AssessmentAnalysisController CreateController(IServiceScope scope, string id)
    {
        return new AssessmentAnalysisController(scope.ServiceProvider.GetRequiredService<IAssessmentAnalysisService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}