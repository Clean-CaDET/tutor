using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.Domain.LearningUtilities;
using Tutor.Core.UseCases.Learning.Utilities;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Web.Controllers.Learners.Learning.Utilities.Notes;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/unit/{unitId:int}/notes")]
public class NoteController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly INoteService _noteService;

    public NoteController(IMapper mapper, INoteService noteService)
    {
        _noteService = noteService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<List<NoteDto>> GetLearnersNotes(int unitId)
    {
        var result = _noteService.GetAppropriateNotes(User.LearnerId(), unitId);
        return CreateResponse<Note, NoteDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpGet("export")]
    public ActionResult<List<NoteDto>> ExportLearnersNotes(int unitId)
    {
        var result = _noteService.GetNotesExport(User.LearnerId(), unitId);
        return File(result.Value, "text/markdown", "NotesFromUnit" + unitId + ".md");
    }

    [HttpPost]
    public ActionResult<NoteDto> Create([FromBody] NoteDto noteDto)
    {
        var note = _mapper.Map<Note>(noteDto);
        note.LearnerId = User.LearnerId();
        var result = _noteService.Create(note);
        return CreateResponse<Note, NoteDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpPut("{noteId:int}")]
    public ActionResult<NoteDto> Update([FromBody] NoteDto noteDto)
    {
        var note = _mapper.Map<Note>(noteDto);
        note.LearnerId = User.LearnerId();
        var result = _noteService.Update(note);
        return CreateResponse<Note, NoteDto>(result, Ok, CreateErrorResponse, _mapper);
    }

    [HttpDelete("{noteId:int}")]
    public ActionResult Delete(int noteId)
    {
        var result = _noteService.Delete(noteId, User.LearnerId());
        return CreateResponse(result, Ok, CreateErrorResponse);
    }
}