using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Internal;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Courses.Core.Domain.TokenWallet;

namespace Tutor.Courses.Core.UseCases.Management;

public class TokenSpendingService : ITokenSpendingService
{
    private readonly IWalletRepository _walletRepository;
    private readonly ICrudRepository<KnowledgeUnit> _unitRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TokenSpendingService(IWalletRepository walletRepository,
        ICrudRepository<KnowledgeUnit> unitRepository,
        ICoursesUnitOfWork unitOfWork, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _unitRepository = unitRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result HasSufficientBalance(int learnerId, int courseId, int totalCharacterCount)
    {
        var wallet = _walletRepository.Get(learnerId, courseId);
        if (wallet == null)
            return Result.Fail(FailureCode.NotFound + ": No wallet found for learner");

        if (wallet.RemainingBalance < EstimateTokens(totalCharacterCount))
            return Result.Fail("Insufficient token balance");

        return Result.Ok();
    }

    private static int EstimateTokens(int totalCharacterCount)
    {
        return (totalCharacterCount / 4) + 50;
    }

    public Result<TokenSpendingResultDto> SpendTokens(TokenSpendingRequestDto request)
    {
        var wallet = _walletRepository.Get(request.LearnerId, request.CourseId);
        if (wallet == null)
            return Result.Fail(FailureCode.NotFound + ": No wallet found for learner");
        if (!Enum.TryParse<AiFeatureType>(request.FeatureType, out _))
            return Result.Fail("Invalid feature type: " + request.FeatureType);

        var spendingRequest = _mapper.Map<TokenSpendingRequest>(request);
        var result = wallet.SpendTokens(spendingRequest);

        _walletRepository.Update(wallet);
        var saveResult = _unitOfWork.Save();
        if (saveResult.IsFailed)
            return Result.Fail(saveResult.Errors);

        return new TokenSpendingResultDto
        {
            TokensSpent = spendingRequest.TotalTokens,
            RemainingBalance = result.Value.RemainingBalance
        };
    }

    public Result HasSufficientBalanceForUnit(int learnerId, int unitId, int totalCharacterCount)
    {
        var courseId = ResolveCourseId(unitId);
        if (courseId == 0) return Result.Fail(FailureCode.NotFound + ": Unit not found");
        return HasSufficientBalance(learnerId, courseId, totalCharacterCount);
    }

    public Result<TokenSpendingResultDto> SpendTokensForUnit(TokenSpendingRequestDto request)
    {
        var courseId = ResolveCourseId(request.UnitId);
        if (courseId == 0) return Result.Fail(FailureCode.NotFound + ": Unit not found");
        request.CourseId = courseId;
        return SpendTokens(request);
    }

    private int ResolveCourseId(int unitId)
    {
        var unit = _unitRepository.Get(unitId);
        return unit?.CourseId ?? 0;
    }
}
