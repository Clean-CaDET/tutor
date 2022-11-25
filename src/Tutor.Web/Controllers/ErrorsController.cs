using Microsoft.AspNetCore.Mvc;

namespace Tutor.Web.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult HandleErrors() => Problem();
}