using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Domain;

public class TokenWallet : Entity
{
    // minimum amount for conversation
    private static readonly int _threshold = 1000;
    public int LearnerId { get; private set; }
    public int CourseId { get; private set; }
    public int Amount { get; private set; }

    private TokenWallet() {}
    public TokenWallet(int learnerId, int courseId)
    {
        LearnerId = learnerId;
        CourseId = courseId;
        // TODO: allow configuration by admin
        // amount = token_amount_per_dollar * dollars
        Amount = 20000 * 10;
    }

    public bool CheckAmount()
    {
        return Amount >= _threshold;
    }

    public void ReduceAmount(int amount)
    {
        Amount -= amount;
    }
}
