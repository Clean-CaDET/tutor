using FluentResults;

namespace Tutor.Stakeholders.API.Internal;

public interface IInternalWalletService
{
    Result SpendFunds(int learnerId, int amount);
}