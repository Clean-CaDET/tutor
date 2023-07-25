namespace Tutor.LanguageModel.API.Dtos;

public class MessageDto
{
    // prilikom slanja prve poruke se kreira chat sa tim id-em
    public int ChatId { get; set; }
    public int ContextId { get; set; }
    public ContextType ContextType { get; set; }
    public MessageType Type { get; set; }
    public string? Message { get; set; }
}

public enum MessageType
{
    OpenEndedLecture, // -> context KC
    OpenEndedTask, // -> context AI
    // actions -> message not present in request
    Summarize, // -> context KC
    SimilarTask, // -> context AI (can also be KC)
    Keywords, // -> context KC
    LectureQuestions // -> context KC
}

public enum ContextType
{
    Lecture, // KC
    Task // AI
}
