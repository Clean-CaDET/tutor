using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Infrastructure.Smtp;

namespace Tutor.Web.Controllers.Instructors.Monitoring;

[Authorize(Policy = "instructorPolicy")]
[Route("api/monitoring/progress")]
public class ProgressOverviewController : BaseApiController
{
    private readonly IEmailSender _emailSender;

    public ProgressOverviewController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost("overview")]
    public ActionResult SendOverviewMessage(Message message)
    {
        _emailSender.SendAsync(message);
        return Ok();
    }

    [HttpPost("overview/bulk")]
    public ActionResult SendBulkOverviewMessage(List<Message> messages)
    {
        _emailSender.SendBulkAsync(messages);
        return Ok();
    }
}