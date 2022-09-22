using System.Linq;
using AutoMapper;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.AssessmentItems.AIMicroChallenges;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.AIMicroChallenges;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ArrangeTasks;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiChoiceQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ShortAnswerQuestions;

namespace Tutor.Web.Controllers.Domain
{
    public class AssessmentItemsProfile : Profile
    {
        public AssessmentItemsProfile()
        {
            CreateMap<AssessmentItem, AssessmentItemDto>().IncludeAllDerived();

            #region Short answer question
            CreateMap<Saq, SaqDto>();
            CreateMap<SaqEvaluation, SaqEvaluationDto>();
            CreateMap<SaqSubmissionDto, SaqSubmission>();
            #endregion

            #region Multiple choice question
            CreateMap<Mcq, McqDto>();
            CreateMap<McqEvaluation, McqEvaluationDto>();
            CreateMap<McqSubmissionDto, McqSubmission>();
            #endregion

            #region Multiple response question
            CreateMap<Mrq, MrqDto>();
            CreateMap<MrqItem, MrqItemDto>();
            CreateMap<MrqSubmissionDto, MrqSubmission>()
                .ForMember(dest => dest.SubmittedAnswerIds, opt => opt.MapFrom(src => src.Answers.Select(a => a.Id)));
            CreateMap<MrqEvaluation, MrqEvaluationDto>();
            CreateMap<MrqItemEvaluation, MrqItemEvaluationDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FullItem.Id))
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
                .AfterMap((src, dest, context) =>
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

            #region AiMicroChallenge
            CreateMap<AIMicroChallenge, AIMicroChallengeDto>();
            CreateMap<AIMicroChallengeEvaluation, AIMicroChallengeEvaluationDto>();
            CreateMap<AIMicroChallengeHint, AIMicroChallengeHintDto>();
            CreateMap<AIMicroChallengeSubmission, AIMicroChallengeSubmissionDto>();
            #endregion
        }
    }
}
