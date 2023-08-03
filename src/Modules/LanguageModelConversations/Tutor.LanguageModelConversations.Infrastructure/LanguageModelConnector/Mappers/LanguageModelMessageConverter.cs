using AutoMapper;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Mappers;

public class LanguageModelMessageConverter : ITypeConverter<Response.LanguageModelDto, List<LanguageModelMessage>>
{
    public List<LanguageModelMessage> Convert(Response.LanguageModelDto source, List<LanguageModelMessage> destination, ResolutionContext context)
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
                    // DONE: pitati aleka da li sistemski promptovi da se cuvaju u bazi
                    // DA -> sistemski promptovi treba da se cuvaju u bazi
                    continue;
                case Response.SenderType.Human:
                    // TODO: prosiri model koji on vraca tako da ima informaciju i o tome koji je tip poruke vracen
                    // maper odradi sve ostalo, mi samo setujemo u metodi konektora
                    destMessage = new LanguageModelMessage()
                    {
                        Content = message.Data.Content,
                        SenderType = SenderType.Learner,
                    };
                    destMessages.Add(destMessage);
                    break;
                case Response.SenderType.Ai:
                    destMessage = new LanguageModelMessage()
                    {
                        // TODO: u domenskom modelu se mora nalaziti LanguageModelQaMessage i LanguageModelKeywordMessage kako bismo mogli da deserijalizujemo sadrzaj ispod za front
                        // moze se nalaziti u api dto paketu
                        // "{\"lista\": [\n  {\"pitanje\": \"Ko je zec u lekciji?\", \"odgovor\": \"pera\"},\n  {\"pitanje\": \"Ko je mis u lekciji?\", \"odgovor\": \"mika\"},\n  {\"pitanje\": \"Ko je dinosaurus u lekciji?\", \"odgovor\": \"lena\"}\n  ]\n}"
                        // "{\"lista\": [\n  {\"kljucna_rec\": \"lekcija\", \"objasnjenje\": \"Lekcija je deo gradiva koji se predaje ili uči u okviru određenog kursa ili predmeta.\"},\n  {\"kljucna_rec\": \"zec\", \"objasnjenje\": \"Zec je mali sisavac koji pripada porodici zečeva.\"},\n  {\"kljucna_rec\": \"dinosaurus\", \"objasnjenje\": \"Dinosaurusi su izumrli gmizavci koji su živeli pre milionima godina.\"}\n  ]\n}"
                        Content = message.Data.Content,
                        SenderType = SenderType.LanguageModel,
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
