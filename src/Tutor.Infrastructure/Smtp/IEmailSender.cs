using System.Collections.Generic;

namespace Tutor.Infrastructure.Smtp
{
    public interface IEmailSender
    {
        void SendAsync(Message message);
        void SendBulkAsync(List<Message> messages);
    }
}
