using AutoMapper;
using Tutor.Core.DomainModel.Units;
using Tutor.Web.Controllers.Units.DTOs;

namespace Tutor.Web.Controllers.Units.Mappers
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDTO>();
            CreateMap<UnitKnowledgeComponent, UnitKnowledgeComponentDTO>();
        }
    }
}