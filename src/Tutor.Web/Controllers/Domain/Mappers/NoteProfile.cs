using AutoMapper;
using Tutor.Core.DomainModel.Notes;
using Tutor.Web.Controllers.Domain.DTOs.Notes;

namespace Tutor.Web.Controllers.Domain.Mappers
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