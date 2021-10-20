using AutoMapper;
using Tutor.Core.KnowledgeComponentModel.KnowledgeComponents;
using Tutor.Web.Controllers.KCs.DTOs;

namespace Tutor.Web.Controllers.KCs
{
    public class KCProfile : Profile
    {
        public KCProfile()
        {
            CreateMap<KnowledgeComponent, KnowledgeComponentDTO>();
        }
    }
}