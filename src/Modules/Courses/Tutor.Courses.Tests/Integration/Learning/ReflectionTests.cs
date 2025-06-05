using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Learning;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Learning;

[Collection("Sequential")]
public class ReflectionTests : BaseCoursesIntegrationTest
{
    public ReflectionTests(CoursesTestFactory factory) : base(factory) { }

    [Theory]
    [InlineData("-2", -2, 1)]
    [InlineData("-2", -3, 1)]
    public void Gets_reflections_for_enrolled_unit(string learnerId, int unitId, int expectedReflectionCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId);
        var result = ((OkObjectResult)controller.GetAll(unitId).Result!).Value as List<ReflectionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedReflectionCount);
    }

    [Fact]
    public void Does_not_retrieve_reflections_for_unenrolled_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");

        var response = (ObjectResult)controller.GetAll(-2).Result!;

        response.ShouldNotBeNull();
        response.StatusCode.ShouldBe(403);
    }

    [Theory]
    [InlineData("-2", -1, 5)]
    [InlineData("-2", -2, 3)]
    public void Gets_reflection(string learnerId, int reflectionId, int expectedQuestionCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId);
        var result = ((OkObjectResult)controller.Get(reflectionId).Result!).Value as ReflectionDto;

        result.ShouldNotBeNull();
        result.Questions.Count.ShouldBe(expectedQuestionCount);
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void Submits_reflection_answer(string learnerId, int reflectionId, ReflectionAnswerDto answer)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.SubmitAnswer(reflectionId , answer);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.ReflectionAnswers.Single();
        storedEntity.ShouldNotBeNull();
        storedEntity.ReflectionId.ShouldBe(reflectionId);
        storedEntity.Answers.Count.ShouldBe(answer.Answers.Count);
        storedEntity.Answers
            .All(storedA => answer.Answers
                .Any(a => a.Answer == storedA.Answer && a.QuestionId == storedA.QuestionId))
            .ShouldBeTrue();
    }

    public static IEnumerable<object[]> GetData()
    {
        return new List<object[]>
        {
            new object[]
            {
                "-2",
                -1,
                new ReflectionAnswerDto
                {
                    Answers = new List<ReflectionQuestionAnswerDto>
                    {
                        new() {QuestionId = -1, Answer = "Nimalo"},
                        new() {QuestionId = -2, Answer = "Nimalo"},
                        new() {QuestionId = -3, Answer = "Teški su"},
                        new() {QuestionId = -4, Answer = "Slab"},
                        new() {QuestionId = -5, Answer = ""}
                    }
                }
            },
            new object[]
            {
                "-2",
                -2,
                new ReflectionAnswerDto
                {
                    Answers = new List<ReflectionQuestionAnswerDto>
                    {
                        new() {QuestionId = -11, Answer = "Nimalo"},
                        new() {QuestionId = -12, Answer = "Nimalo"},
                        new() {QuestionId = -13, Answer = "Slab"}
                    }
                }
            }
        };
    }

    private static ReflectionController CreateController(IServiceScope scope, string id)
    {
        return new ReflectionController(scope.ServiceProvider.GetRequiredService<IReflectionService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}