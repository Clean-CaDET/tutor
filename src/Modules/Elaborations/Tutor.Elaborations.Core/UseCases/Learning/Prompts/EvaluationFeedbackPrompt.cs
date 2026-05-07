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
        sb.AppendLine("  <misconceptions>: CM ključevi koje je učenik pogrešno primenio");
        sb.AppendLine("    <misconception key=\"M1\" probeCount=\"0|1\"/>: probeCount = broj puta probeovano bez napretka");
        sb.AppendLine("  <gaps>: nedostaci u KP/KR elaboraciji");
        sb.AppendLine("    <gap key=\"P1\" type=\"proposition|relation\" grade=\"-1|0|1\" probeCount=\"0|1\"/>");
        sb.AppendLine("      grade: -1 = netačna tvrdnja | 0 = izostavljena oblast | 1 = nejasna/parcijalna tvrdnja");
        sb.AppendLine("      probeCount: broj puta probeovano bez napretka");
        sb.AppendLine();

        sb.AppendLine("Stavke su već odabrane i prioritizovane. Daj povratnu informaciju za svaku stavku.");
        sb.AppendLine();

        sb.AppendLine("# Smernice po tipu i broju proba");
        sb.AppendLine();
        sb.AppendLine("Misconceptions:");
        sb.AppendLine("  probeCount=0: Imenuj zabludu i objasni zašto je pogrešna; pozovi učenika da je ispravi.");
        sb.AppendLine("  probeCount=1: Pojačaj ispravku konkretnim kontrastom ili primerom; budi direktniji.");
        sb.AppendLine();
        sb.AppendLine("Gaps — grade=\"-1\" (netačno):");
        sb.AppendLine("  probeCount=0: Postavi pitanje koje dovodi u pitanje netačnu tvrdnju, bez otkrivanja odgovora.");
        sb.AppendLine("  probeCount=1: Imenuj grešku direktno i kratko objasni zašto je netačna; pozovi na ispravku.");
        sb.AppendLine("Gaps — grade=\"0\" (izostavlja oblast):");
        sb.AppendLine("  probeCount=0: Postavi otvoreno pitanje koje poziva učenika da pokrije tu oblast.");
        sb.AppendLine("  probeCount=1: Naznači direktno da je ta oblast izostavljena; daj usmerenje bez otkrivanja odgovora.");
        sb.AppendLine("Gaps — grade=\"1\" (nejasno/parcijalno):");
        sb.AppendLine("  probeCount=0: Postavi pitanje koje traži veću preciznost ili dubinu.");
        sb.AppendLine("  probeCount=1: Imenuj šta nedostaje u preciznosti; ukaži šta bi potpuniji odgovor sadržao.");
        sb.AppendLine();

        sb.AppendLine("# Format izlaza");
        sb.AppendLine("Samo tekst povratne informacije na srpskom. Svaka stavka u novom paragrafu.");
        sb.AppendLine("Bez naslova, bez numerisanja, bez dodatnog teksta.");

        return sb.ToString();
    }
}
