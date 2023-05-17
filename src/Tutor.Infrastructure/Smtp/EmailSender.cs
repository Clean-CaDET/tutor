using FluentResults;
using MailKit.Net.Proxy;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Infrastructure.Smtp;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _config;
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(EmailConfiguration config, ILogger<EmailSender> logger)
    {
        _config = config;
        _logger = logger;
    }

    public async void SendAsync(Message message)
    {
        var email = CreateEmail(message);
        using var smtp = await OpenConnection();
        if (smtp is null)
            return;

        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async void SendBulkAsync(List<Message> messages)
    {
        var emails = messages.Select(x => CreateEmail(x));
        using var smtp = await OpenConnection();
        if (smtp is null)
            return;

        foreach (var email in emails)
        {
            await smtp.SendAsync(email);
        }
        await smtp.DisconnectAsync(true);
    }

    private MimeMessage CreateEmail(Message message)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config.Username));
        email.To.AddRange(message.To.Select(x => MailboxAddress.Parse(x)));
        email.Subject = message.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = message.Content };
        return email;
    }

    private async Task<SmtpClient> OpenConnection()
    {
        try
        {
            _logger.LogInformation("EmailConfigUsername: {@Username}, EmailConfigPassword: {@Password}", 
                _config.Username, _config.Password);
            _logger.LogInformation("EmailConfigSmtpHost: {@SmtpHost}, EmailConfigSmtpPort: {@SmtpPort}",
                _config.SmtpHost, _config.SmtpPort);
            _logger.LogInformation("EmailConfigProxyAddress: {@ProxyAddress}, EmailConfigProxyPort: {@ProxyPort}",
                _config.ProxyAddress, _config.ProxyPort);

            var smtp = new SmtpClient();
            smtp.ProxyClient = new HttpProxyClient(_config.ProxyAddress, _config.ProxyPort);
            await smtp.ConnectAsync(_config.SmtpHost, _config.SmtpPort, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config.Username, _config.Password);
            return smtp;
        } catch (Exception e)
        {
            Error rootError = new Error(e.Message).CausedBy(e);
            var result = Result.Fail(FailureCode.InternalServerError).WithError(rootError);
            _logger.LogError("Error: {@Errors}.", result.Errors);
            return null;
        }
    }
}