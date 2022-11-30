using System.Collections.Generic;
using System.Text;

namespace Tutor.Infrastructure.Database.DataImport.Learner;

internal static class LearnerToSqlTransformer
{
    internal static string Transform(List<UserLearnerColumns> learners)
    {
        var sqlBuilder = new StringBuilder();
        sqlBuilder.AppendLine().AppendLine();
        foreach (var learner in learners)
        {
            sqlBuilder.Append("INSERT INTO public.\"Users\"(\"Id\", \"Username\", \"Password\", \"Salt\", \"Role\", \"IsActive\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + learner.Id + ", '" + learner.Index + "', '"
                              + learner.Password + "', '" + learner.Salt + "', 2, true);");
            sqlBuilder.AppendLine().AppendLine();

            sqlBuilder.Append("INSERT INTO public.\"Learners\"(\"Id\", \"UserId\", \"Index\", \"Name\", \"Surname\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + learner.Id + ", " + learner.Id + ", '" + learner.Index + "', '"
                              + learner.Name + "', '" + learner.Surname + "');");
            sqlBuilder.AppendLine().AppendLine();
        }
        return sqlBuilder.ToString();
    }
}