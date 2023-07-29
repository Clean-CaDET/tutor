using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Domain;

public class TokenWallet : Entity
{
    // number of tokens allowed to go over
    private static readonly decimal _threshold = 1000m;
    public int LearnerId { get; private set; }
    // TODO: Da li odmah vezujemo za Learner i Course? -> nije problem rekla bih
    // Sa fronta prosledjujemo i taj parametar
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

    public bool ChechAmount()
    {
        return Amount >= _threshold;
    }

    public void ReduceAmount(int amount)
    {
        Amount -= amount;
    }
}
