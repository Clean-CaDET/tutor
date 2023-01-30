using AutoMapper;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Web.Mappings;

public class CourseCloneProfile : Profile
{
    public CourseCloneProfile()
    {
        CreateMap<KnowledgeUnit, KnowledgeUnit>()
            .ForMember(dest => dest.CourseId, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<KnowledgeComponent, KnowledgeComponent>()
            .ForMember(dest => dest.KnowledgeUnitId, opt => opt.Ignore())
            .ForMember(dest => dest.ParentId, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<InstructionalItem, InstructionalItem>().IncludeAllDerived()
            .ForMember(dest => dest.KnowledgeComponentId, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Markdown, Markdown>();
        CreateMap<Image, Image>();
        CreateMap<Video, Video>();

        CreateMap<AssessmentItem, AssessmentItem>().IncludeAllDerived()
            .ForMember(dest => dest.KnowledgeComponentId, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Saq, Saq>();
        CreateMap<Mcq, Mcq>();
        CreateMap<Mrq, Mrq>();
    }
}