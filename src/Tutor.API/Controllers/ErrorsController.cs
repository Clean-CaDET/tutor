using Microsoft.AspNetCore.Mvc;

namespace Tutor.API.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    [Route("/error")]
    public IActionResult HandleErrors() => Problem();
}