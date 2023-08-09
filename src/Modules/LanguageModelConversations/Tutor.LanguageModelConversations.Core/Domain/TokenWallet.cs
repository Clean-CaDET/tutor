using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Domain;

public class TokenWallet : Entity
{
    // number of tokens allowed to go over
    private static readonly int _threshold = 1000;
    public int LearnerId { get; private set; }
    public int CourseId { get; private set; }
    public int Amount { get; private set; }

    private TokenWallet() {}
    // kolicina tokena fiksna trenutno, admin moze da definise sa fronta
    // TODO: na kraju, odmah dodati polja za koja se prosledjuju odneklud kao konfiguracija
    // ili ne
    // hocemo da to admin radi, znaci cuvace se u bazi i bice vezano na nivou kursa
    public TokenWallet(int learnerId, int courseId)
    {
        LearnerId = learnerId;
        CourseId = courseId;
        // amount = amount_per_dollar * dollars
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
