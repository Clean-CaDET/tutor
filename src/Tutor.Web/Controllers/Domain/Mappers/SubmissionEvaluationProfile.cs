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
            CreateMap<ChallengeEvaluation, ChallengeEvaluationDTO>()
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
            CreateMap<ChallengeHint, ChallengeHintDTO>();
            CreateMap<ChallengeSubmissionDTO, ChallengeSubmission>();

            CreateMap<MRQSubmissionDTO, MRQSubmission>()
                .ForMember(dest => dest.SubmittedAnswerIds, opt => opt.MapFrom(src => src.Answers.Select(a => a.Id)));
            CreateMap<MRQEvaluation, MRQItemEvaluation>();
            CreateMap<MRQItemEvaluation, MRQItemEvaluationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FullItem.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.FullItem.Text))
                .ForMember(dest => dest.Feedback, opt => opt.MapFrom(src => src.FullItem.Feedback));

            CreateMap<ArrangeTaskEvaluation, ArrangeTaskEvaluationDTO>();
            CreateMap<ArrangeTaskContainerEvaluation, ArrangeTaskContainerEvaluationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FullAnswer.Id))
                .ForMember(dest => dest.CorrectElements, opt => opt.MapFrom(src => src.FullAnswer.Elements));
            CreateMap<ArrangeTaskSubmissionDTO, ArrangeTaskSubmission>();
            CreateMap<ArrangeTaskContainerDTO, ArrangeTaskContainerSubmission>()
                .ForMember(dest => dest.ElementIds, opt => opt.MapFrom(src => src.Elements.Select(e => e.Id)))
                .ForMember(dest => dest.ContainerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
