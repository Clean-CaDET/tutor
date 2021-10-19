using AutoMapper;
using Tutor.Web.Controllers.KnowledgeComponent.DTOs;

namespace Tutor.Web.Controllers.KnowledgeComponent
{
    public class KCProfile : Profile
    {
        public KCProfile()
        {
            CreateMap<Core.KnowledgeComponentModel.KnowledgeComponents.KnowledgeComponent, KnowledgeComponentDTO>();
        }
    }
}