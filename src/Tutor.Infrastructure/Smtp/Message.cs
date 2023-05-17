using System.Collections.Generic;

namespace Tutor.Infrastructure.Smtp;

public class Message
{
    public List<string> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
}