using AutoMapper;
using Tutor.LearningUtils.API.Dtos;
using Tutor.LearningUtils.Core.Domain;

namespace Tutor.LearningUtils.Core.Mappers;

public class NoteProfile : Profile
{
    public NoteProfile()
    {
        CreateMap<NoteDto, Note>();
        CreateMap<Note, NoteDto>();
    }
}