using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Infrastructure.Smtp;

namespace Tutor.Web.Controllers.Instructors.Monitoring
{
    [Authorize(Policy = "instructorPolicy")]
    [Route("api/monitoring/progress")]
    public class ProgressOverviewController : BaseApiController
    {
        private readonly IEmailService _emailService;

        public ProgressOverviewController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("overview")]
        public ActionResult SendOverviewMessage(Message message)
        {
            _emailService.SendAsync(message);
            return Ok();
        }

        [HttpPost("overview/bulk")]
        public ActionResult SendBulkOverviewMessage(List<Message> messages)
        {
            _emailService.SendBulkAsync(messages);
            return Ok();
        }
    }
}
