using AutoMapper;
using Tutor.Core.ProgressModel.Progress;
using Tutor.Web.Controllers.Progress.DTOs.Progress;

namespace Tutor.Web.Controllers.Progress.Mappers
{
    public class ProgressProfile: Profile
    {
        public ProgressProfile()
        {
            CreateMap<NodeProgress, KnowledgeNodeProgressDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Node.Id))
                .ForMember(dest => dest.LearningObjective, opt => opt.MapFrom(src => src.Node.LearningObjective));
        }
    }
}
