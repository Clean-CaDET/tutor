using Microsoft.AspNetCore.Mvc;

namespace Tutor.Web.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    [Route("/error")]
    public IActionResult HandleErrors() => Problem();
}