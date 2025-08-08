using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Internal;
using Tutor.Stakeholders.API.Internal;
using Tutor.Stakeholders.API.Public;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Core.UseCases;

public class WalletService : IWalletService, IInternalWalletService
{
    private readonly IWalletRepository _walletRepository;
    private readonly IStakeholdersUnitOfWork _unitOfWork;
    private readonly IInternalMembershipService _membershipService;

    public WalletService(IWalletRepository walletRepository, IStakeholdersUnitOfWork unitOfWork, IInternalMembershipService membershipService)
    {
        _walletRepository = walletRepository;
        _unitOfWork = unitOfWork;
        _membershipService = membershipService;
    }

    public Result TopOffFunds(int learnerId, int amount)
    {
        var wallet = _walletRepository.GetByLearnerId(learnerId);
        if (wallet == null)
        {
            _walletRepository.Create(new Wallet(learnerId, amount));
            return _unitOfWork.Save();
        }

        var result = wallet.AddTokens(amount);
        if (result.IsFailed)
            return Result.Fail(result.Errors);

        _walletRepository.Update(wallet);
        return _unitOfWork.Save();
    }

    public Result TopOffFundsByCourse(int courseId, int amount)
    {
        var learnerIds = _membershipService.GetMemberIdsByCourse(courseId);
        var wallets = _walletRepository.GetByLearnerIds(learnerIds);

        foreach (var learnerId in learnerIds)
        {
            var wallet = wallets.FirstOrDefault(w => w.LearnerId == learnerId);
            if (wallet == null)
            {
                _walletRepository.Create(new Wallet(learnerId, amount));
                continue;
            }

            var result = wallet.AddTokens(amount);
            if (result.IsFailed) continue;

            _walletRepository.Update(wallet);
        }

        return _unitOfWork.Save();
    }

    public Result<int> GetFunds(int learnerId)
    {
        return _walletRepository.GetByLearnerId(learnerId)?.AvailableTokens ?? 0;
    }

    public Result SpendFunds(int learnerId, int amount)
    {
        var wallet = _walletRepository.GetByLearnerId(learnerId);
        if (wallet == null)
            return Result.Fail(FailureCode.NotFound);

        var result = wallet.DeductTokens(amount);
        if (result.IsFailed)
            return Result.Fail(result.Errors);

        _walletRepository.Update(wallet);
        _unitOfWork.Save();
        return Result.Ok();
    }
}