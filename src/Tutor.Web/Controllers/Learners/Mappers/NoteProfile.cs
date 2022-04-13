using AutoMapper;
using Tutor.Core.LearnerModel.Notes;
using Tutor.Web.Controllers.Learners.DTOs.Notes;

namespace Tutor.Web.Controllers.Learners.Mappers
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