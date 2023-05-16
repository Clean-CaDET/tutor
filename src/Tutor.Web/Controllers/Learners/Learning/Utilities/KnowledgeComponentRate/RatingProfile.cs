using AutoMapper;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Web.Controllers.Learners.Learning.Utilities.KnowledgeComponentRate;

public class RatingProfile : Profile
{
    public RatingProfile()
    {
        CreateMap<KnowledgeComponentRatingDto, KnowledgeComponentRating>();
        CreateMap<KnowledgeComponentRating, KnowledgeComponentRatingDto>();
    }
}