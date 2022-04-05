using AutoMapper;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;

namespace Tutor.Web.Controllers.Domain.DTOs.InstructorFeedback
{
    public class InstructorMessageProfile : Profile
    {
        public InstructorMessageProfile()
        {
            CreateMap<InstructorMessageDto, InstructorMessageEvent>();
        }
    }
}