using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Internal;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Courses.Core.Domain.TokenWallet;

namespace Tutor.Courses.Core.UseCases.Management;

public class TokenSpendingService : ITokenSpendingService
{
    private readonly IWalletRepository _walletRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TokenSpendingService(IWalletRepository walletRepository, ICoursesUnitOfWork unitOfWork, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<TokenSpendingResultDto> SpendTokens(TokenSpendingRequestDto request)
    {
        var wallet = _walletRepository.Get(request.LearnerId, request.CourseId);
        if (wallet == null)
            return Result.Fail(FailureCode.NotFound + ": No wallet found for learner");

        if (!Enum.TryParse<AiFeatureType>(request.FeatureType, out var featureType))
            return Result.Fail("Invalid feature type: " + request.FeatureType);

        var spendingRequest = _mapper.Map<TokenSpendingRequest>(request);

        var result = wallet.SpendTokens(spendingRequest);
        if (result.IsFailed)
            return Result.Fail(result.Errors);

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
}
