using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.LearnerModel.Notes;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Web.Controllers.Learners.Notes
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/notes/")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;

        public NoteController(IMapper mapper, INoteService noteService)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<NoteDto> SaveNote([FromBody] NoteDto noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);
            note.LearnerId = User.LearnerId();
            var result = _noteService.Save(note);
            return Ok(_mapper.Map<NoteDto>(result.Value));
        }

        [HttpPut]
        public ActionResult<NoteDto> UpdateNote([FromBody] NoteDto noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);
            note.LearnerId = User.LearnerId();
            var result = _noteService.Update(note);
            return Ok(_mapper.Map<NoteDto>(result.Value));
        }

        [HttpDelete("{noteId:int}")]
        public ActionResult<int> DeleteNote(int noteId)
        {
            var result = _noteService.Delete(noteId);
            return Ok(result.Value);
        }

        [HttpGet("{unitId:int}")]
        public ActionResult<List<NoteDto>> GetAppropriateNotes(int unitId)
        {
            var result = _noteService.GetAppropriateNotes(User.LearnerId(), unitId);
            return Ok(result.Value.Select(note => _mapper.Map<NoteDto>(note)).ToList());
        }
    }
}