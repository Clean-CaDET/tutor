using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningUtils.API.Dtos;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Utilities;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/unit/{unitId:int}/notes")]
public class NoteController : BaseApiController
{
    private readonly INoteService _noteService;
    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }
        
    [HttpGet]
    public ActionResult<List<NoteDto>> GetLearnersNotes(int unitId)
    {
        var result = _noteService.GetAppropriateNotes(User.LearnerId(), unitId);
        return CreateResponse(result);
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
        noteDto.LearnerId = User.LearnerId();
        var result = _noteService.Create(noteDto);
        return CreateResponse(result);
    }

    [HttpPut("{noteId:int}")]
    public ActionResult<NoteDto> Update([FromBody] NoteDto noteDto)
    {
        noteDto.LearnerId = User.LearnerId();
        var result = _noteService.Update(noteDto);
        return CreateResponse(result);
    }

    [HttpDelete("{noteId:int}")]
    public ActionResult Delete(int noteId)
    {
        var result = _noteService.Delete(noteId, User.LearnerId());
        return CreateResponse(result);
    }
}