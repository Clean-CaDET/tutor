using System;
using System.Linq;
using AutoMapper;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ShortAnswerQuestions;

namespace Tutor.Web.Mappings.Knowledge;

public class AssessmentItemsProfile : Profile
{
    public AssessmentItemsProfile()
    {
        CreateMap<AssessmentItemDto, AssessmentItem>().IncludeAllDerived();
        CreateMap<AssessmentItem, AssessmentItemDto>().IncludeAllDerived();
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

        #region ArrangeTask
        CreateMap<ArrangeTask, AtDto>()
            .ForMember(dest => dest.UnarrangedElements, opt => opt.MapFrom(src => src.Containers.SelectMany(c => c.Elements).ToList()));
        CreateMap<ArrangeTaskContainer, AtContainerDto>();
        CreateMap<ArrangeTaskElement, AtElementDto>();
        CreateMap<ArrangeTaskEvaluation, AtEvaluationDto>();
        CreateMap<ArrangeTaskContainerEvaluation, AtContainerEvaluationDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FullAnswer.Id))
            .ForMember(dest => dest.CorrectElements, opt => opt.MapFrom(src => src.FullAnswer.Elements));
        CreateMap<AtSubmissionDto, ArrangeTaskSubmission>();
        CreateMap<AtContainerSubmissionDto, ArrangeTaskContainerSubmission>();
        #endregion
            
        #region Challenge
        CreateMap<Challenge, ChallengeDto>();
        CreateMap<ChallengeEvaluation, ChallengeEvaluationDto>()
            .ForMember(dest => dest.ApplicableHints, opt => opt.MapFrom(src => src.ApplicableHints.GetHints()))
            .AfterMap((src, dest, _) =>
            {
                var hintDirectory = src.ApplicableHints.GetDirectory();
                var directoryKeys = src.ApplicableHints.GetHints();
                foreach (var hintDto in dest.ApplicableHints)
                {
                    var relatedHint = directoryKeys.First(h => h.Id == hintDto.Id);
                    hintDto.ApplicableToCodeSnippets = hintDirectory[relatedHint];
                }
            });
        CreateMap<ChallengeHint, ChallengeHintDto>();
        CreateMap<ChallengeSubmissionDto, ChallengeSubmission>();
        #endregion
    }
}