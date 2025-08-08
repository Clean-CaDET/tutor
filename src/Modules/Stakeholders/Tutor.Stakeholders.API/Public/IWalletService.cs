using FluentResults;

namespace Tutor.Stakeholders.API.Public;

public interface IWalletService
{
    Result TopOffFunds(int learnerId, int amount);
    Result TopOffFundsByCourse(int courseId, int amount);
}