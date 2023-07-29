using Tutor.BuildingBlocks.Core.Domain;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Dtos.Integration.Response;

namespace Tutor.LanguageModelConversations.Core.Domain;

public class Conversation : Entity
{
    public int LearnerId { get; private set; }
    // ContextType -> koji modul pozivati za ucitavanje konteksta
    public int ContextId { get; private set; }
    // TODO: proveriti da li cuvati jednu za prikaz, jednu za slanje
        // problem sto moramo da cuvamo lm poruke u originalnoj strukturi kako bismo ih vratili llm-u
        // neke poruke imaju posebna mapiranja unutar sebe gde se deserijalizuju sa tutor-ai strane i ne bih da dupliramo posao ovde, pogotovo ako se nacin promeni
    public List<LmMessageDto> LmMessages { get; private set; }
    // definisati poseban domenski model koji ce imati mapiranja na flask ulaz i flask izlaz
    // samo se domenski model cuva u bazi
    public List<ConversationMessageDto> Messages { get; private set; }

    // cuvamo domenske objekte u bazi
    // imamo dto objekte za integraciju sa alek api
    // imamo dto objekte za front
    // alek_api -> domenski objekat -> front_dto
    //      infra_konverter    core_konverter
    //      ne mora biti pametan (cuvamo u bazi u obliku u kom moramo da posaljemo aleku, baza cuva objekte za tamo)
    //                         mora biti pametam (cuvamo objekte koje umemo da prikazemo na frontu)
    // umesto da oba budu pametna, nama je nebitno u kom obliku ce nam biti u bazi, ne menjamo ih nikako
    //                         pametni konverter slozenih objekata + vec postojeci mapper kod

    public Conversation(int id, int learnerId, int contextId)
    {
        Id = id;
        LearnerId = learnerId;
        ContextId = contextId;
        LmMessages = new List<LmMessageDto>();
        Messages = new List<ConversationMessageDto>();
    }

    public void AddLmMessages(List<LmMessageDto> lmMessages)
    {
        LmMessages.AddRange(lmMessages);
    }

    public void AddMessages(ConversationMessageDto request, ConversationMessageDto response)
    {
        request.Sender = SenderType.Learner;
        Messages.Add(request);
        response.Sender = SenderType.Lm;
        Messages.Add(response);
    }
}
