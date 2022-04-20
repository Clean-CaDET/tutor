using AutoMapper;
using Tutor.Core.LearnerModel.Notes;

namespace Tutor.Web.Controllers.Learners.Notes
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<NoteDto, Note>();
            CreateMap<Note, NoteDto>();
        }
    }
}