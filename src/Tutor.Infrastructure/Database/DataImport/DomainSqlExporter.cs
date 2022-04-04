using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.DomainExcelModel;

namespace Tutor.Infrastructure.Database.DataImport;

public static class DomainSqlExporter
{
    public static string BuildSql(DomainExcelContent content)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append(BuildUnitsSql(content.Units));
        sqlBuilder.Append(BuildKCsSql(content.KnowledgeComponents));
        sqlBuilder.Append(BuildIEsSql(content.InstructionalItems));
        sqlBuilder.Append(BuildAEsSql(content.AssessmentItems));

        return sqlBuilder.ToString();
    }

    private static string BuildUnitsSql(List<UnitColumns> units)
    {
        var sqlBuilder = new StringBuilder();

        foreach (var unit in units)
        {
            sqlBuilder.Append("INSERT INTO public.\"Units\"(\"Id\", \"Code\", \"Name\", \"Description\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + unit.Id + ", '" + unit.Code + "', '"
                              + unit.Name + "', '" + unit.Description + "');");
            sqlBuilder.AppendLine().AppendLine();
        }

        return sqlBuilder.ToString();
    }

    private static string BuildKCsSql(List<KCColumns> kcs)
    {
        var sqlBuilder = new StringBuilder();

        foreach (var kc in kcs)
        {
            sqlBuilder.Append("INSERT INTO public.\"KnowledgeComponents\"(\"Id\", \"Code\", \"Name\", \"Description\", \"UnitId\", \"ParentId\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + kc.Id + ", '" + kc.Code + "', '"
                              + kc.Name + "', '" + kc.Description + "', "
                              + (kc.UnitId == 0 ? "NULL" : kc.UnitId) + ", "
                              + (kc.ParentId == 0 ? "NULL" : kc.ParentId) + ");");
            sqlBuilder.AppendLine().AppendLine();
        }

        return sqlBuilder.ToString();
    }

    private static string BuildIEsSql(List<IEColumns> ies)
    {
        var sqlBuilder = new StringBuilder();

        foreach (var ie in ies)
        {
            sqlBuilder.Append("INSERT INTO public.\"InstructionalItems\"(\"Id\", \"KnowledgeComponentId\", \"Order\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + ie.Id + ", " + ie.KnowledgeComponentId + ", " + ie.Order + ");");
            sqlBuilder.AppendLine();
            switch (ie.Type)
            {
                case "text": sqlBuilder.Append(BuildTextSql(ie));
                    break;
                case "image": sqlBuilder.Append(BuildImageSql(ie));
                    break;
                case "video": sqlBuilder.Append(BuildVideoSql(ie));
                    break;
            }
        }

        return sqlBuilder.ToString();
    }

    private static string BuildTextSql(IEColumns ie)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append("INSERT INTO public.\"Texts\"(\"Id\", \"Content\") VALUES");
        sqlBuilder.AppendLine();
        sqlBuilder.Append("\t(" + ie.Id + ", '" + ie.Text + "');");
        sqlBuilder.AppendLine().AppendLine();
        return sqlBuilder.ToString();
    }

    private static string BuildImageSql(IEColumns ie)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append("INSERT INTO public.\"Images\"(\"Id\", \"Url\", \"Caption\") VALUES");
        sqlBuilder.AppendLine();
        sqlBuilder.Append("\t(" + ie.Id + ", '" + ie.Url + "', '" + ie.Caption + "');");
        sqlBuilder.AppendLine().AppendLine();
        return sqlBuilder.ToString();
    }

    private static string BuildVideoSql(IEColumns ie)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append("INSERT INTO public.\"Videos\"(\"Id\", \"Url\") VALUES");
        sqlBuilder.AppendLine();
        sqlBuilder.Append("\t(" + ie.Id + ", '" + ie.Url + "');");
        sqlBuilder.AppendLine().AppendLine();
        return sqlBuilder.ToString();
    }

    private static string BuildAEsSql(List<AEColumns> aes)
    {
        var sqlBuilder = new StringBuilder();

        foreach (var ae in aes)
        {
            sqlBuilder.Append("INSERT INTO public.\"AssessmentItems\"(\"Id\", \"KnowledgeComponentId\", \"Order\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + ae.Id + ", " + ae.KnowledgeComponentId + ", " + ae.Order + ");");
            sqlBuilder.AppendLine();
            switch (ae.Type)
            {
                case "mrq":
                    sqlBuilder.Append(BuildMrqSql(ae));
                    break;
                case "at":
                    sqlBuilder.Append(BuildAtSql(ae));
                    break;
                case "saq":
                    sqlBuilder.Append(BuildSaqSql(ae));
                    break;
                case "ch":
                    sqlBuilder.Append(BuildChSql(ae));
                    sqlBuilder.AppendLine();
                    break;
            }
        }
        sqlBuilder.AppendLine().AppendLine();
        return sqlBuilder.ToString();
    }

    private static string BuildMrqSql(AEColumns ae)
    {
        var sqlBuilder = new StringBuilder();
        var startingItemId = ae.Id * 10; //There won't be more than 10 items per AE

        sqlBuilder.Append("INSERT INTO public.\"MultiResponseQuestions\"(\"Id\", \"Text\") VALUES");
        sqlBuilder.AppendLine();
        sqlBuilder.Append("\t(" + ae.Id + ", '" + ae.Text + "');");
        sqlBuilder.AppendLine();
        foreach (var mrqItem in ae.Items)
        {
            var itemParts = mrqItem.Split('\n');
            sqlBuilder.Append("INSERT INTO public.\"MrqItems\"(\"Id\", \"Text\", \"IsCorrect\", \"Feedback\", \"MrqId\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + startingItemId-- + ", '" + itemParts[0] + "', "
                              + itemParts[1] + ", '" + itemParts[2] + "', " + ae.Id + ");");
            sqlBuilder.AppendLine();
        }

        sqlBuilder.AppendLine().AppendLine();
        return sqlBuilder.ToString();
    }

    private static string BuildAtSql(AEColumns ae)
    {
        var sqlBuilder = new StringBuilder();
        var startingContainerId = ae.Id * 10; //There won't be more than 10 containers per AT

        sqlBuilder.Append("INSERT INTO public.\"ArrangeTasks\"(\"Id\", \"Text\") VALUES");
        sqlBuilder.AppendLine();
        sqlBuilder.Append("\t(" + ae.Id + ", '" + ae.Text + "');");
        sqlBuilder.AppendLine();
        foreach (var atContainers in ae.Items)
        {
            var itemParts = atContainers.Split('\n');
            sqlBuilder.Append("INSERT INTO public.\"ArrangeTaskContainers\"(\"Id\", \"ArrangeTaskId\", \"Title\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + startingContainerId-- + ", " + ae.Id + ", '" + itemParts[0] + "');");
            sqlBuilder.AppendLine();
            sqlBuilder.Append(BuildAtElementSql(itemParts, startingContainerId+1));
        }

        sqlBuilder.AppendLine().AppendLine();
        return sqlBuilder.ToString();
    }

    private static string BuildAtElementSql(string[] itemParts, int startingContainerId)
    {
        var startingElementId = startingContainerId * 10; //There won't be more than 10 items per container
        var sqlBuilder = new StringBuilder();
        for (var i = 1; i < itemParts.Length; i+=2)
        {
            sqlBuilder.Append("INSERT INTO public.\"ArrangeTaskElements\"(\"Id\", \"ArrangeTaskContainerId\", \"Text\", \"Feedback\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + startingElementId-- + "," + startingContainerId + ", '"
                              + itemParts[i] + "', '" + itemParts[i+1] + "');");
            sqlBuilder.AppendLine();
        }

        return sqlBuilder.ToString();
    }

    private static string BuildSaqSql(AEColumns ae)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append("INSERT INTO public.\"ShortAnswerQuestions\"(\"Id\", \"Text\", \"AcceptableAnswers\") VALUES");
        sqlBuilder.AppendLine();
        //'{"Enroll","newCourse","Maximum","Active"}'
        sqlBuilder.Append("\t(" + ae.Id + ", '" + ae.Text + "', '{" + BuildSaqItems(ae.Items) + "}');");
        sqlBuilder.AppendLine().AppendLine();
        return sqlBuilder.ToString();
    }

    private static string BuildSaqItems(List<string> items)
    {
        items = items.Select(i => "\"" + i + "\"").ToList();
        return string.Join(", ", items);
    }

    private static string BuildChSql(AEColumns ae)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append("INSERT INTO public.\"Challenges\"(\"Id\", \"Description\", \"Url\", \"TestSuiteLocation\", \"SolutionUrl\") VALUES");
        sqlBuilder.AppendLine();
        sqlBuilder.Append("\t(" + ae.Id + ", '" + ae.Text + "', '" + ae.Items[0] + "', '" + ae.Items[1] + "', '" + ae.Items[2] + "');");
        sqlBuilder.AppendLine().Append("--TODO: STRATEGIES AND HINTS").AppendLine();
        return sqlBuilder.ToString();
    }
}