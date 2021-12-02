using AutoMapper;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion;

namespace Tutor.Web.Controllers.Domain.Mappers
{
    public class SubmissionEvaluationProfile : Profile
    {
        public SubmissionEvaluationProfile()
        {
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

            CreateMap<MrqSubmissionDto, MrqSubmission>()
                .ForMember(dest => dest.SubmittedAnswerIds, opt => opt.MapFrom(src => src.Answers.Select(a => a.Id)));
            CreateMap<MrqEvaluation, MrqEvaluationDto>();
            CreateMap<MrqItemEvaluation, MrqItemEvaluationDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FullItem.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.FullItem.Text))
                .ForMember(dest => dest.Feedback, opt => opt.MapFrom(src => src.FullItem.Feedback));

            CreateMap<ArrangeTaskEvaluation, ArrangeTaskEvaluationDto>();
            CreateMap<ArrangeTaskContainerEvaluation, ArrangeTaskContainerEvaluationDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FullAnswer.Id))
                .ForMember(dest => dest.CorrectElements, opt => opt.MapFrom(src => src.FullAnswer.Elements));
            CreateMap<ArrangeTaskSubmissionDto, ArrangeTaskSubmission>();
            CreateMap<ArrangeTaskContainerSubmissionDto, ArrangeTaskContainerSubmission>();
        }
    }
}
