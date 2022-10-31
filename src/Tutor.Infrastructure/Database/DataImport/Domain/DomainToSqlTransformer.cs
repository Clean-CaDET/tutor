using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel;

namespace Tutor.Infrastructure.Database.DataImport.Domain;

public static class DomainToSqlTransformer
{
    public static string TransformFull(DomainExcelContent content)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append(BuildCoursesSql(content.Courses));
        sqlBuilder.Append(BuildUnitsSql(content.Units));
        sqlBuilder.Append(BuildKCsSql(content.KnowledgeComponents));
        sqlBuilder.Append(BuildIEsSql(content.InstructionalItems));
        sqlBuilder.Append(BuildAEsSql(content.AssessmentItems));

        return sqlBuilder.ToString();
    }

    private static string BuildCoursesSql(List<CourseColumns> courses)
    {
        var sqlBuilder = new StringBuilder();

        foreach (var course in courses)
        {
            sqlBuilder.Append("INSERT INTO public.\"Courses\"(\"Id\", \"Code\", \"Name\", \"Description\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + course.Id + ", '" + course.Code + "', '" + course.Name + "', '" + course.Description + "');");
            sqlBuilder.AppendLine().AppendLine();
        }

        return sqlBuilder.ToString();
    }

    private static string BuildUnitsSql(List<UnitColumns> units)
    {
        var sqlBuilder = new StringBuilder();

        foreach (var unit in units)
        {
            sqlBuilder.Append("INSERT INTO public.\"KnowledgeUnits\"(\"Id\", \"Code\", \"Name\", \"Description\", \"CourseId\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + unit.Id + ", '" + unit.Code + "', '"
                              + unit.Name + "', '" + unit.Description + "', " + unit.CourseId + ");");
            sqlBuilder.AppendLine().AppendLine();
        }

        return sqlBuilder.ToString();
    }

    private static string BuildKCsSql(List<KCColumns> kcs)
    {
        var sqlBuilder = new StringBuilder();

        foreach (var kc in kcs)
        {
            sqlBuilder.Append("INSERT INTO public.\"KnowledgeComponents\"(\"Id\", \"Code\", \"Name\", \"Description\", \"ExpectedDurationInMinutes\", \"KnowledgeUnitId\", \"ParentId\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + kc.Id + ", '" + kc.Code + "', '"
                              + kc.Name + "', '" + kc.Description + "', "
                              + kc.ExpectedDurationInMinutes + ", "
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
        sqlBuilder.Append("INSERT INTO public.\"Videos\"(\"Id\", \"Url\", \"Caption\") VALUES");
        sqlBuilder.AppendLine();
        sqlBuilder.Append("\t(" + ie.Id + ", '" + ie.Url + "', '" + ie.Caption + "');");
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
                case "mcq":
                    sqlBuilder.Append(BuildMcqSql(ae));
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

    private static string BuildMcqSql(AEColumns ae)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append("INSERT INTO public.\"MultiChoiceQuestions\"(\"Id\", \"Text\", \"PossibleAnswers\", \"CorrectAnswer\", \"Feedback\") VALUES");
        sqlBuilder.AppendLine();
        var correctAnswer = FindMcqCorrectAnswerAndFeedback(ae.Items).Split("\n");
        sqlBuilder.Append("\t(" + ae.Id + ", '" + ae.Text + "', '{" + BuildMcqAnswers(ae.Items) + "}', '" +
                          correctAnswer[0] + "', ' " + correctAnswer[2] +"');");
        sqlBuilder.AppendLine().AppendLine();
        return sqlBuilder.ToString();
    }

    private static string FindMcqCorrectAnswerAndFeedback(List<string> aeItems)
    {
        return aeItems.First(item => item.Split('\n')[1].ToLower() == "true");
    }

    private static string BuildMcqAnswers(List<string> aeItems)
    {
        var answers = aeItems.Select(item => "\"" + item.Split('\n')[0] + "\"");
        return string.Join(',', answers);
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