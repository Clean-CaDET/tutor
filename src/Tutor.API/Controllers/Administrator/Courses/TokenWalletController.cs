using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Public.Management;

namespace Tutor.API.Controllers.Administrator.Courses;

[Authorize(Policy = "administratorPolicy")]
[Route("api/management/courses/{courseId:int}/learners/{learnerId:int}/wallet")]
public class TokenWalletController : BaseApiController
{
    private readonly ITokenWalletService _walletService;

    public TokenWalletController(ITokenWalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpGet]
    public ActionResult<TokenWalletDto> Get(int learnerId, int courseId)
    {
        var result = _walletService.GetWallet(learnerId, courseId);
        return CreateResponse(result);
    }

    [HttpPost("deposit")]
    public ActionResult Deposit(int learnerId, int courseId, [FromBody] TokenDepositDto depositDto)
    {
        var result = _walletService.DepositTokens(learnerId, courseId, depositDto.Amount, depositDto.Reason);
        return CreateResponse(result);
    }
}
