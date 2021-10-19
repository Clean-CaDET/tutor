using System.Linq;
using AutoMapper;
using Tutor.Core.ContentModel.LearningObjects;
using Tutor.Core.ContentModel.LearningObjects.ArrangeTasks;
using Tutor.Core.ContentModel.LearningObjects.Challenges;
using Tutor.Core.ContentModel.LearningObjects.Questions;
using Tutor.Core.ContentModel.Lectures;
using Tutor.Web.Controllers.Content.DTOs;

namespace Tutor.Web.Controllers.Content.Mappers
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<Lecture, LectureDTO>()
                .ForMember(dest => dest.KnowledgeNodeIds, opt => opt.MapFrom(src => src.KnowledgeNodes.Select(n => n.Id)));

            CreateMap<LearningObject, LearningObjectDTO>().IncludeAllDerived();
            CreateMap<Text, TextDTO>();
            CreateMap<Image, ImageDTO>();
            CreateMap<Video, VideoDTO>();
            CreateMap<Challenge, ChallengeDTO>();

            CreateMap<Question, QuestionDTO>();
            CreateMap<QuestionAnswer, QuestionAnswerDTO>();

            CreateMap<ArrangeTask, ArrangeTaskDTO>()
                .ForMember(dest => dest.UnarrangedElements, opt => opt.MapFrom(src => src.Containers.SelectMany(c => c.Elements).ToList()));
            CreateMap<ArrangeTaskContainer, ArrangeTaskContainerDTO>();
            CreateMap<ArrangeTaskElement, ArrangeTaskElementDTO>();
        }
    }
}
