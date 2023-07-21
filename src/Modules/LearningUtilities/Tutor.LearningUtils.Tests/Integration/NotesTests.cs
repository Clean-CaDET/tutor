using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Utilities;
using Tutor.LearningUtils.API.Dtos;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.LearningUtils.Infrastructure.Database;

namespace Tutor.LearningUtils.Tests.Integration;

[Collection("Sequential")]
public class NotesTests : BaseLearningUtilsIntegrationTest
{
     public NotesTests(LearningUtilsTestFactory factory) : base(factory) {}

    [Fact]
    public void Creates_new_note()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupNotesController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningUtilsContext>();
        var noteDto = new NoteDto() { Text = "Test", UnitId = -1 };
        dbContext.Database.BeginTransaction();

        var note = ((OkObjectResult)controller.Create(noteDto).Result)?.Value as NoteDto;

        note.Text.ShouldBe("Test");
    }

    [Fact]
    public void Deletes_existing_note()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupNotesController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningUtilsContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-1);

        result.StatusCode.ShouldBe(200);
    }

    [Fact]
    public void Updates_existing_note()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupNotesController(scope, "-1");
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningUtilsContext>();
        dbContext.Database.BeginTransaction();

        var updatedEntity = new NoteDto() { Text = "Test update", Id = -2, UnitId = -1 };
        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as NoteDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(updatedEntity.Id);
        result.UnitId.ShouldBe(updatedEntity.UnitId);
        result.Text.ShouldBe(updatedEntity.Text);
    }

    [Fact]
    public void Gets_stored_notes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupNotesController(scope, "-1");

        var notes = ((OkObjectResult)controller.GetLearnersNotes(-1).Result)?.Value as List<NoteDto>;
        notes.Count.ShouldBe(2);
    }

    private static NoteController SetupNotesController(IServiceScope scope, string id)
    {
        return new NoteController(scope.ServiceProvider.GetRequiredService<INoteService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}