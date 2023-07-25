namespace Tutor.LanguageModel.Core.Domain;

public class Chat
{
    public int Id { get; private set; }
    public int LearnerId { get; private set; }
    public string Content { get; set; }
}
