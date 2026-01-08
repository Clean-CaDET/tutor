using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Management;

public class TokenWalletService : ITokenWalletService
{
    private readonly IMapper _mapper;
    private readonly IWalletRepository _walletRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;

    public TokenWalletService(IMapper mapper, IWalletRepository walletRepository, IOwnedCourseRepository ownedCourseRepository, ICoursesUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _walletRepository = walletRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<TokenWalletDto> GetWallet(int learnerId, int courseId)
    {
        var wallet = _walletRepository.Get(learnerId, courseId);
        if (wallet == null) return Result.Fail<TokenWalletDto>(FailureCode.NotFound);

        return _mapper.Map<TokenWalletDto>(wallet);
    }

    public Result DepositTokens(int learnerId, int courseId, int amount, string reason, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var wallet = _walletRepository.Get(learnerId, courseId);
        if (wallet == null) return Result.Fail(FailureCode.NotFound);

        var result = wallet.DepositTokens(amount, reason);
        if (result.IsFailed) return result;

        _walletRepository.Update(wallet);
        return _unitOfWork.Save();
    }
}
