namespace Tutor.Courses.API.Dtos.TokenWallet;

public class TokenSpendingRequestDto
{
    public int LearnerId { get; set; }
    public int CourseId { get; set; }
    public int UnitId { get; set; }
    public int PromptTokens { get; set; }
    public int CompletionTokens { get; set; }
    public string FeatureType { get; set; } = string.Empty; // "Kc", "Task", "Reflection", "Elaboration"
    public int? EntityId { get; set; }
    public string? PromptSummary { get; set; }
}

public class TokenSpendingResultDto
{
    public int TokensSpent { get; set; }
    public int RemainingBalance { get; set; }
}
