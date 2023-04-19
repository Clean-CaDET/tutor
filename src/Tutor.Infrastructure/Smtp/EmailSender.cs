using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailKit.Net.Proxy;

namespace Tutor.Infrastructure.Smtp;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _config;
    public EmailSender(EmailConfiguration config)
    {
        _config = config;
    }

    public async void SendAsync(Message message)
    {
        var email = CreateEmail(message);
        using var smtp = await OpenConnection();

        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async void SendBulkAsync(List<Message> messages)
    {
        var emails = messages.Select(x => CreateEmail(x));
        using var smtp = await OpenConnection();

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
        var smtp = new SmtpClient();
        smtp.ProxyClient = new HttpProxyClient(_config.ProxyAddress, _config.ProxyPort);
        await smtp.ConnectAsync(_config.SmtpHost, _config.SmtpPort, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_config.Username, _config.Password);
        return smtp;
    }
}