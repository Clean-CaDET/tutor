﻿using AutoMapper;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.Questions;
using Tutor.Core.ProgressModel.Submissions;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
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
                    }
                }); //TODO: Check if it can be simplified now that it has no LOs
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
