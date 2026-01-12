using System.Text;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

public class KcChatPromptFactory
{
    private const string SystemPromptTemplate = """
        Ti si pomoćnik za učenje koji pomaže studentima da razumeju gradivo.

        TVOJA ULOGA:
        - Odgovaraš na pitanja studenata koristeći isključivo priloženi materijal.
        - Daješ kratke, jasne i tačne odgovore.
        - Ako odgovor nije u materijalu, iskreno reci da nemaš tu informaciju.
        - Ohrabruješ studente da razmišljaju samostalno.

        PRAVILA:
        - Koristi srpski jezik.
        - Budi koncizan - odgovori ne treba da budu duži od 2-3 pasusa.
        - Ne izmišljaj informacije koje nisu u materijalu.
        - Ako pitanje nije jasno, zatraži pojašnjenje.

        MATERIJAL:
        {0}
        """;

    public static CompletionRequest CreateRequest(string userQuestion, IReadOnlyList<InstructionalItem> instructionalItems)
    {
        var context = BuildContext(instructionalItems);
        var systemPrompt = string.Format(SystemPromptTemplate, context);

        return CompletionRequest.SingleMessage(
            userMessage: userQuestion,
            systemPrompt: systemPrompt,
            maxTokens: null,
            temperature: 0.3);
    }

    private static string BuildContext(IReadOnlyList<InstructionalItem> items)
    {
        if (items.Count == 0)
            return "Nema dostupnog materijala za ovu temu.";

        var contextBuilder = new StringBuilder();
        for (var i = 0; i < items.Count; i++)
        {
            var content = ExtractContent(items[i]);
            if (string.IsNullOrWhiteSpace(content)) continue;

            contextBuilder.AppendLine($"[Materijal {i + 1}]");
            contextBuilder.AppendLine(content);
            contextBuilder.AppendLine();
        }

        return contextBuilder.Length > 0
            ? contextBuilder.ToString()
            : "Nema dostupnog materijala za ovu temu.";
    }

    private static string? ExtractContent(InstructionalItem item)
    {
        return item switch
        {
            Markdown markdown => markdown.Content,
            _ => null
        };
    }
}
