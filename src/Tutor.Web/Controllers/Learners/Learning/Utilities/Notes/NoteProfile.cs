using AutoMapper;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Web.Controllers.Learners.Learning.Utilities.Notes
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