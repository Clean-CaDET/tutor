using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.LearnerModel.Notes;
using Tutor.Web.Controllers.Learners.Notes;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learners
{
    [Collection("Sequential")]
    public class NotesTests : BaseWebIntegrationTest
    {
        public NotesTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public void Creates_new_note()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupNotesController(scope, "-2");

            var noteDto = new NoteDto() {Text = "Test", UnitId = -1};
            var note = ((OkObjectResult) controller.SaveNote(noteDto).Result)?.Value as NoteDto;
            
            note.Text.ShouldBe("Test");
        }

        [Fact]
        public void Deletes_existing_note()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupNotesController(scope, "-2");
            
            var id = ((OkObjectResult) controller.DeleteNote(-1).Result)?.Value;
            id.ShouldBe(-1);
        }

        [Fact]
        public void Updates_existing_note()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupNotesController(scope, "-1");

            var noteDto = new NoteDto() {Text = "Test update", Id = -2, UnitId = -1};
            var note = ((OkObjectResult) controller.UpdateNote(noteDto).Result)?.Value as NoteDto;
            
            note.Text.ShouldBe("Test update");
        }

        [Fact]
        public void Gets_stored_notes()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupNotesController(scope, "-1");
            
            var notes = ((OkObjectResult) controller.GetAppropriateNotes(-1).Result)?.Value as List<NoteDto>;
            notes.Count.ShouldBe(2);
        }
        
        private static NoteController SetupNotesController(IServiceScope scope, string userId)
        {
            return new NoteController(scope.ServiceProvider.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<INoteService>())
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                        {
                            new Claim("id", userId),
                            new Claim("learnerId", userId)
                        }))
                    }
                }
            };
        }
    }
}