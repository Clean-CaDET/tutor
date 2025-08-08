using FluentResults;

namespace Tutor.Stakeholders.API.Internal;

public interface IInternalWalletService
{
    Result<int> GetFunds(int learnerId);
    Result SpendFunds(int learnerId, int amount);
}