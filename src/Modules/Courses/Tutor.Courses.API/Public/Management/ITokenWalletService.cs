using FluentResults;
using Tutor.Courses.API.Dtos.TokenWallet;

namespace Tutor.Courses.API.Public.Management;

public interface ITokenWalletService
{
    Result<TokenWalletDto> GetWallet(int learnerId, int courseId);
    Result DepositTokens(int learnerId, int courseId, int amount, string reason);
}
