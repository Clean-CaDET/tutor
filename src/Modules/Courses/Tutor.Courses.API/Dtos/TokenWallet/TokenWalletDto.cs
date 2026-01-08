namespace Tutor.Courses.API.Dtos.TokenWallet;

public class TokenWalletDto
{
    public int LearnerId { get; set; }
    public int CourseId { get; set; }
    public int TotalAllowance { get; set; }
    public int TotalSpent { get; set; }
    public int RemainingBalance { get; set; }
}
