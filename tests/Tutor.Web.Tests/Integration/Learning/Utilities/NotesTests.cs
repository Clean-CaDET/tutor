using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.UseCases.Learning.Utilities;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Learners.Learning.Utilities.Notes;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Utilities;

[Collection("Sequential")]
public class NotesTests : BaseWebIntegrationTest
{
    public NotesTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

    [Fact]
    public void Creates_new_note()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupNotesController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
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
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-1);

        result.StatusCode.ShouldBe(200);
    }

    [Fact]
    public void Updates_existing_note()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupNotesController(scope, "-1");
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var noteDto = new NoteDto() { Text = "Test update", Id = -2, UnitId = -1 };
        var result = (OkResult)controller.Update(noteDto);

        result.StatusCode.ShouldBe(200);
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
        return new NoteController(scope.ServiceProvider.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<INoteService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}