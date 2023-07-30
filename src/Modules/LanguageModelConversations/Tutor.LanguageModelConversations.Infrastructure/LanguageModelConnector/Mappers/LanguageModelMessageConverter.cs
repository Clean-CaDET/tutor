using AutoMapper;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Mappers;

public class LanguageModelMessageConverter : ITypeConverter<Response.LanguageModelDto, IEnumerable<LanguageModelMessage>>
{
    public IEnumerable<LanguageModelMessage> Convert(Response.LanguageModelDto source, IEnumerable<LanguageModelMessage> destination, ResolutionContext context)
    {
        // uvek uzimamo poslednje tri najnovije iz odgovora i njih mapiramo
        // jedan response => 3 poruke se apenduju
        var destMessages = new List<LanguageModelMessage>();
        var newMessages = source.Messages.TakeLast(3);
        foreach (var message in newMessages)
        {
            LanguageModelMessage destMessage;
            switch (message.Type)
            {
                case Response.SenderType.System:
                    // TODO: pitati aleka da li sistemski promptovi da se cuvaju u bazi
                    // pros necuvanja:
                    // nepotrebni za prikaz
                    // sigurnosna pretnja

                    // 1) da li su sistemski promptovi neophodni u istoriji za open ended konverzaciju?
                    // 2) da li je neophodan ocuvan redosled system-human-ai da bi istorija bila validna?

                    // potencijalni cons necuvanja:
                    // sistemski prompt je taj na koji on konkatenira lekciju
                    // da li onda gubimo siri kontekst konverzacije?
                    // 1. zapocnem OE konverzaciju u lekciji i posalje se lekcija
                    // 2. nastavim OE konverzaciju u zadatku vezanom za lekciju i pitam nesto
                    // (?) da li se kontekst nece preneti ako ne cuvamo sistemske promptove?
                    // da li mozda da kontekst bude u okviru korisnicke poruke?
                    // tada neophodno parsirati pitanje od konteksta i ne prikazivati na frontu
                    continue;
                case Response.SenderType.Human:
                    // TODO: prosiri model koji on vraca tako da ima informaciju i o tome koji je tip poruke vracen
                    // maper odradi sve ostalo, mi samo setujemo u odgovarajucoj servisnoj metodi
                    destMessage = new LanguageModelMessage()
                    {
                        Content = message.Data.Content,
                        SenderType = SenderType.Learner,
                        // TODO: podeljeno sa 2 ili 3 u zavisnosti da li cuvamo sistemski prompt
                        TokensUsed = source.TokensUsed / 2
                    };
                    destMessages.Add(destMessage);
                    break;
                case Response.SenderType.Ai:
                    destMessage = new LanguageModelMessage()
                    {
                        // TODO: u domenskom modelu se mora nalaziti LanguageModelQaMessage i LanguageModelKeywordMessage kako bismo mogli da deserijalizujemo sadrzaj ispod za front
                        // "{\"lista\": [\n  {\"pitanje\": \"Ko je zec u lekciji?\", \"odgovor\": \"pera\"},\n  {\"pitanje\": \"Ko je mis u lekciji?\", \"odgovor\": \"mika\"},\n  {\"pitanje\": \"Ko je dinosaurus u lekciji?\", \"odgovor\": \"lena\"}\n  ]\n}"
                        // "{\"lista\": [\n  {\"kljucna_rec\": \"lekcija\", \"objasnjenje\": \"Lekcija je deo gradiva koji se predaje ili uči u okviru određenog kursa ili predmeta.\"},\n  {\"kljucna_rec\": \"zec\", \"objasnjenje\": \"Zec je mali sisavac koji pripada porodici zečeva.\"},\n  {\"kljucna_rec\": \"dinosaurus\", \"objasnjenje\": \"Dinosaurusi su izumrli gmizavci koji su živeli pre milionima godina.\"}\n  ]\n}"
                        Content = message.Data.Content,
                        SenderType = SenderType.LanguageModel,
                        // TODO: podeljeno sa 2 ili 3 u zavisnosti da li cuvamo sistemski prompt
                        TokensUsed = source.TokensUsed / 2
                    };
                    destMessages.Add(destMessage);
                    break;
                default:
                    continue;
            }
        }
        return destMessages;
    }
}
