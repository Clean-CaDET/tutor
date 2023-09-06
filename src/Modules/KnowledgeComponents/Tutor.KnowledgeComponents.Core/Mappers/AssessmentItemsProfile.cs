using AutoMapper;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.CodeCompletionQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.CodeCompletionQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;

namespace Tutor.KnowledgeComponents.Core.Mappers;

public class AssessmentItemsProfile : Profile
{
    public AssessmentItemsProfile()
    {
        CreateMap<AssessmentItemDto, AssessmentItem>().IncludeAllDerived()
            .ForMember(dest => dest.Hints, opt => opt.MapFrom(src => src.Hints.Select((h, i) => new Hint(h, i))));
        CreateMap<AssessmentItem, AssessmentItemDto>().IncludeAllDerived()
            .ForMember(dest => dest.Hints, opt => opt.MapFrom(src => src.Hints.Select(h => h.Markdown)));
        CreateMap<SubmissionDto, Submission>().IncludeAllDerived();
        CreateMap<Evaluation, EvaluationDto>().IncludeAllDerived();
        
        CreateMap<Feedback, FeedbackDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.GetName(src.FeedbackType)))
            .ForMember(dest => dest.Hint, opt => opt.MapFrom(src => src.Hint != null ? src.Hint.Markdown : null));

        #region Short answer question
        CreateMap<Saq, SaqDto>().ReverseMap();
        CreateMap<SaqEvaluation, SaqEvaluationDto>();
        CreateMap<SaqSubmissionDto, SaqSubmission>();
        #endregion

        #region Multiple choice question
        CreateMap<Mcq, McqDto>().ReverseMap();
        CreateMap<McqEvaluation, McqEvaluationDto>();
        CreateMap<McqSubmissionDto, McqSubmission>();
        #endregion

        #region Multiple response question
        CreateMap<Mrq, MrqDto>().ReverseMap();
        CreateMap<MrqItem, MrqItemDto>().ReverseMap();
        CreateMap<MrqSubmissionDto, MrqSubmission>()
            .ForMember(dest => dest.SubmittedAnswers, opt => opt.MapFrom(src => src.Answers.Select(a => a.Text)));
        CreateMap<MrqEvaluation, MrqEvaluationDto>();
        CreateMap<MrqItemEvaluation, MrqItemEvaluationDto>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.FullItem.Text))
            .ForMember(dest => dest.Feedback, opt => opt.MapFrom(src => src.FullItem.Feedback));
        #endregion

        #region
        CreateMap<Ccq, CcqDto>().ReverseMap();
        CreateMap<CcqItem, CcqItemDto>().ReverseMap();
        CreateMap<CcqSubmissionDto, CcqSubmission>();
        CreateMap<CcqEvaluation, CcqEvaluationDto>();
        #endregion
    }
}