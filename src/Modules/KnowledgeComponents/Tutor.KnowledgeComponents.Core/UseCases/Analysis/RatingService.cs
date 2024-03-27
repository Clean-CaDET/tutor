using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.Core.UseCases.Analysis;

public class RatingService : BaseService<KnowledgeComponentRatingDto, KnowledgeComponentRating>, IRatingService
{
    private readonly IAccessService _accessService;
    private readonly IKcRatingRepository _ratingRepository;
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly IKnowledgeComponentsUnitOfWork _unitOfWork;
    public RatingService(IAccessService accessService, IKcRatingRepository ratingRepository, IKnowledgeComponentRepository kcRepository, IKnowledgeComponentsUnitOfWork unitOfWork, IMapper mapper): base(mapper)
    {
        _accessService = accessService;
        _ratingRepository = ratingRepository;
        _kcRepository = kcRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<KnowledgeComponentRatingDto> Create(KnowledgeComponentRatingDto rating, int learnerId)
    {
        if(!_accessService.IsEnrolledInKc(rating.KnowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var newRating = _ratingRepository.Create(MapToDomain(rating));
        var result = _unitOfWork.Save();

        if (result.IsFailed) return result;
        return MapToDto(newRating);
    }

    public Result<List<KnowledgeComponentRatingDto>> GetByUnit(int unitId, int instructorId)
    {
        if (!_accessService.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var kcs = _kcRepository.GetByUnit(unitId);
        var ratings = _ratingRepository.GetByKcs(kcs.Select(kc => kc.Id).ToList());
        
        return MapToDto(ratings);
    }
}