using AutoMapper;
using Tutor.LearningUtils.API.Dtos;
using Tutor.LearningUtils.Core.Domain;

namespace Tutor.LearningUtils.Core.Mappers;

public class RatingProfile : Profile
{
    public RatingProfile()
    {
        CreateMap<KnowledgeComponentRatingDto, KnowledgeComponentRating>();
        CreateMap<KnowledgeComponentRating, KnowledgeComponentRatingDto>();
    }
}