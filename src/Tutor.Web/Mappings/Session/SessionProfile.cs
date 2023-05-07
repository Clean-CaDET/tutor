using AutoMapper;

namespace Tutor.Web.Mappings.Session;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<Core.Domain.Session.Session, SessionDto>();
    }
}