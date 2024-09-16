using Microsoft.AspNetCore.Mvc;
using Tutor.Stakeholders.Infrastructure.Database;

namespace Tutor.API.Controllers;

[Route("api/version")]
public class AppVersionController : BaseApiController
{
    private readonly StakeholdersContext _context;

    public AppVersionController(StakeholdersContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        var appVersion = _context.AppVersion.FirstOrDefault();
        return appVersion == null ? "1.0.0" : appVersion.Version;
    }
}