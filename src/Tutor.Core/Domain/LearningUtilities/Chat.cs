using System;

namespace Tutor.Core.Domain.LearningUtilities;

public class Chat
{
    public int Id { get; private set; }
    public int LearnerId { get; private set; }
    public DateTime DateTime { get; private set; }
    public string[] Messages { get; private set; }

    public Chat(int learnerId, DateTime dateTime, string[] messages)
    {
        LearnerId = learnerId;
        DateTime = dateTime;
        Messages = messages;
    }
}
