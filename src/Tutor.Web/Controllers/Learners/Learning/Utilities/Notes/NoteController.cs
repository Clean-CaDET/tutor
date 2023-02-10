using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        return Ok(result.Value.Select(_mapper.Map<NoteDto>).ToList());
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
        return Ok(_mapper.Map<NoteDto>(result.Value));
    }

    [HttpPut("{noteId:int}")]
    public ActionResult Update([FromBody] NoteDto noteDto)
    {
        var note = _mapper.Map<Note>(noteDto);
        note.LearnerId = User.LearnerId();
        _noteService.Update(note);
        return Ok();
    }

    [HttpDelete("{noteId:int}")]
    public ActionResult Delete(int noteId)
    {
        var result = _noteService.Delete(noteId, User.LearnerId());
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok();
    }
}