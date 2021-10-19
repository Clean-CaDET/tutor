using System.Linq;
using AutoMapper;
using Tutor.Core.ContentModel.LearningObjects.ArrangeTasks;
using Tutor.Core.ContentModel.LearningObjects.Challenges;
using Tutor.Core.ContentModel.LearningObjects.Questions;
using Tutor.Core.ProgressModel.Submissions;
using Tutor.Web.Controllers.Content.DTOs;
using Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation;

namespace Tutor.Web.Controllers.Progress.Mappers
{
    public class SubmissionProfile : Profile
    {
        public SubmissionProfile()
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
                        if (relatedHint.LearningObjectSummaryId == null) continue;
                        var relatedLO = src.ApplicableLOs
                            .First(lo => lo.LearningObjectSummaryId == relatedHint.LearningObjectSummaryId);
                        hintDto.LearningObject = context.Mapper.Map<LearningObjectDTO>(relatedLO);
                    }
                });
            CreateMap<ChallengeHint, ChallengeHintDTO>();
            CreateMap<ChallengeSubmissionDTO, ChallengeSubmission>();

            CreateMap<QuestionSubmissionDTO, QuestionSubmission>()
                .ForMember(dest => dest.SubmittedAnswerIds, opt => opt.MapFrom(src => src.Answers.Select(a => a.Id)));
            CreateMap<AnswerEvaluation, AnswerEvaluationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FullAnswer.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.FullAnswer.Text))
                .ForMember(dest => dest.Feedback, opt => opt.MapFrom(src => src.FullAnswer.Feedback));

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
