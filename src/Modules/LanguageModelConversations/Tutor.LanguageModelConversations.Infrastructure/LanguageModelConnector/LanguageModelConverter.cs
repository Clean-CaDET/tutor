using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.LanguageModelConversations.Core.UseCases;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector;

public class LanguageModelConverter : ILanguageModelConverter
{
    public string ConvertAssessmentItem(AssessmentItemDto assessmentItem)
    {
        // AI to formatted string

        // neophodno formatirati u obliku:
        /*
         * # TEKST ZADATKA:

           Potrebno je napisati program koji:

           ## PONUĐENI ODGOVORI:

           Izbor: U 6. liniji treba obrnuti promenljive.
           Odgovor: netačno.
        */
        throw new NotImplementedException();
    }

    public string ConvertInstructionalItems(List<InstructionalItemDto> instructionalItems)
    {
        // List<II> to formatted string

        //foreach (var n in nesto)
        //{
        //    n.
        //}
        // prodji kroz sve ii i ucitaj Content (ako je text) ili Caption (ako je bilo sta drugo)
        // hau d fak...
        // moram ga pitati kog je tipa i onda na osnovu toga uzimati vrednost
        throw new NotImplementedException();
    }
}
