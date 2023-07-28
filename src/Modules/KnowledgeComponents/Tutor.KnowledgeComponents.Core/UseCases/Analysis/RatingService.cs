using AutoMapper;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Interfaces.Analysis;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.Core.UseCases.Analysis;

public class RatingService : CrudService<KnowledgeComponentRatingDto, KnowledgeComponentRating>, IRatingService
{
    public RatingService(ICrudRepository<KnowledgeComponentRating> ratingRepository,
        IKnowledgeComponentsUnitOfWork unitOfWork,
        IMapper mapper): base(ratingRepository, unitOfWork, mapper) {}
}