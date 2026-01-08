using FluentResults;
using Tutor.Courses.API.Dtos.TokenWallet;

namespace Tutor.Courses.API.Internal;

/// <summary>
/// Service for other modules to record token spending.
/// </summary>
public interface ITokenSpendingService
{
    /// <summary>
    /// Checks balance and records token spending for an AI call.
    /// Returns error if hard cap exceeded or insufficient balance.
    /// Returns warning in result if soft cap exceeded.
    /// </summary>
    Result<TokenSpendingResultDto> SpendTokens(TokenSpendingRequestDto request);
}
