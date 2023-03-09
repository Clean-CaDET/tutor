using System.Collections.Generic;

namespace Tutor.Infrastructure.Smtp
{
    public interface IEmailService
    {
        void SendAsync(Message message);
        void SendBulkAsync(List<Message> messages);
    }
}
