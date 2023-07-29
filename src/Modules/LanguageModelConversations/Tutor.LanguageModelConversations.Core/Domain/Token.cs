using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Domain;

// TokenWallet klasa
public class Token : Entity
{
    // number of tokens allowed to go over
    private static readonly decimal _threshold = 1000m;
    public int LearnerId { get; private set; }
    // neophodan i courseId
    // Amount
    public decimal Count { get; private set; }

    private Token() {}

    // fiksno trenutno, admin moze da definise sa fronta
    public Token(int learnerId)
    {
        LearnerId = learnerId;
        // broj_tokena = broj_tokena_po_dolaru * broj_dolara
        // broj_tokena = 20k * 10$
        // 1k 0.03 kad mi saljemo
        // 1k 0.06 kad on salje
        // ~ 0.05
        // konstruktor ce primati ispod vrednosti kada bude konfigurabilno
        // count = count_per_dollar * amount
        Count = 20000 * 10;
    }
    // IOptionsMonitor<T> se moze koristiti za izmenu vrednosti u runtime
    // moze da posmatrati fajl
    // Pitanje: koji fajl moze biti koriscen?

    public bool ChechCount()
    {
        return Count >= _threshold;
    }

    public void ReduceCount(decimal reduction)
    {
        Count -= reduction;
    }
}
