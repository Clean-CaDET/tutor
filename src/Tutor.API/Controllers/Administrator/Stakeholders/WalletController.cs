using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Stakeholders.API.Public;

namespace Tutor.API.Controllers.Administrator.Stakeholders;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/learners/{learnerId:int}/wallets")]
public class WalletController : BaseApiController
{
    private readonly IWalletService _walletService;

    public WalletController(IWalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpPost]
    public ActionResult TopOffFunds(int learnerId, [FromBody] int amount)
    {
        var result = _walletService.TopOffFunds(learnerId, amount);
        return CreateResponse(result);
    }
}