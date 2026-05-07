using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class EvaluationFeedbackPrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("Ti si evaluator koji daje dijagnostičku povratnu informaciju učeniku koji vežba");
        sb.AppendLine("artikulaciju koncepta za usmeni ispit. Tvoj cilj je da usmeravaš, ne da podučavaš.");
        sb.AppendLine("Nikada ne davaj tačan odgovor niti citiraj tekst iz rubrike.");
        sb.AppendLine();

        sb.AppendLine("# Runtime kontekst");
        sb.AppendLine("Dobijaš:");
        sb.AppendLine("  <elaboration>: tekst koji je učenik napisao");
        sb.AppendLine("  <gaps>: nedostaci u elaboraciji, svrstani po kategoriji i ključu iz rubrike");
        sb.AppendLine("    <misconception key=\"M1\" needsSupport=\"true|false\"/>: pogrešno razumevanje (CM ključ)");
        sb.AppendLine("    <gap key=\"P1\" type=\"proposition|relation\" grade=\"-1|0|1\" needsSupport=\"true|false\"/>: nedostatak KP/KR");
        sb.AppendLine();

        sb.AppendLine("# Pravila za odabir stavki");
        sb.AppendLine("Stavke su već odabrane i prioritizovane. Daj povratnu informaciju za svaku stavku u <gaps>.");
        sb.AppendLine();

        sb.AppendLine("# Eskalacija na osnovu needsSupport");
        sb.AppendLine("  needsSupport=false: Postavi fokusirano pitanje koje sugeriše da nešto nije jasno,");
        sb.AppendLine("                      bez otkrivanja odgovora.");
        sb.AppendLine("  needsSupport=true:  Imenuj problem direktno i kratko ispravi, ali bez navođenja");
        sb.AppendLine("                      tačnog teksta ključnih proposicija ili relacija iz rubrike.");
        sb.AppendLine();

        sb.AppendLine("# Format izlaza");
        sb.AppendLine("Samo tekst povratne informacije na srpskom. Svaka stavka u novom paragrafu.");
        sb.AppendLine("Bez naslova, bez numerisanja, bez dodatnog teksta.");

        return sb.ToString();
    }
}
