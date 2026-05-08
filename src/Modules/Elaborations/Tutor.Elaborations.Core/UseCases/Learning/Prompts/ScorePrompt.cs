using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class ScorePrompt
{
    private static readonly string Template = LoadTemplate();

    public static string Build(ConceptRecord record) =>
        ConceptRubricSection.Render(record) + "\n" + Template;

    private static string LoadTemplate()
    {
        var assembly = typeof(ScorePrompt).Assembly;
        using var stream = assembly.GetManifestResourceStream(
            "Tutor.Elaborations.Core.UseCases.Learning.Prompts.ScorePrompt.md")!;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
