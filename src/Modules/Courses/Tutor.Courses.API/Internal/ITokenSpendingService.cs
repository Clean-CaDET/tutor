using FluentResults;
using Tutor.Courses.API.Dtos.TokenWallet;

namespace Tutor.Courses.API.Internal;

/// <summary>
/// Service for other modules to check balance and record token spending.
/// </summary>
public interface ITokenSpendingService
{
    /// <summary>
    /// Checks if the learner has enough tokens for an LLM call based on prompt character count.
    /// </summary>
    Result HasSufficientBalance(int learnerId, int courseId, int totalCharacterCount);

    /// <summary>
    /// Records token spending for a completed LLM call.
    /// </summary>
    Result<TokenSpendingResultDto> SpendTokens(TokenSpendingRequestDto request);

    /// <summary>
    /// Checks balance by resolving courseId from unitId internally.
    /// </summary>
    Result HasSufficientBalanceForUnit(int learnerId, int unitId, int totalCharacterCount);

    /// <summary>
    /// Records token spending, resolving courseId from the request's UnitId.
    /// </summary>
    Result<TokenSpendingResultDto> SpendTokensForUnit(TokenSpendingRequestDto request);
}
