using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.DomainExcelModel;

namespace Tutor.Infrastructure.Database.DataImport
{
    internal static class LearnerSqlExporter
    {
        internal static string BuildSql(List<UserLearnerColumns> learners, List<KCColumns> kcs, List<UnitColumns> units)
        {
            return BuildUserLearnerSql(learners) + BuildMasterySql(learners, kcs, units);
        }

        private static string BuildUserLearnerSql(List<UserLearnerColumns> learners)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine().AppendLine();
            foreach (var learner in learners)
            {
                sqlBuilder.Append("INSERT INTO public.\"Users\"(\"Id\", \"Username\", \"Password\", \"Salt\", \"Role\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + learner.Id + ", '" + learner.Index + "', '"
                                  + learner.Password + "', '" + learner.Salt + "', 2);");
                sqlBuilder.AppendLine().AppendLine();

                sqlBuilder.Append("INSERT INTO public.\"Learners\"(\"Id\", \"UserId\", \"Index\", \"Name\", \"Surname\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + learner.Id + ", " + learner.Id + ", '" + learner.Index + "', '"
                                    + learner.Name + "', '" + learner.Surname + "');");
                sqlBuilder.AppendLine().AppendLine();
            }

            return sqlBuilder.ToString();
        }

        private static string BuildMasterySql(List<UserLearnerColumns> learners, List<KCColumns> kcs, List<UnitColumns> units)
        {
            var sqlBuilder = new StringBuilder();
            var startingId = -100000;
            foreach (var learnerId in learners.Select(l => l.Id))
            {
                foreach (var unit in units)
                {
                    sqlBuilder.Append(
                        "INSERT INTO public.\"UnitEnrollments\"(\"Id\", \"LearnerId\", \"KnowledgeUnitId\", \"Start\", \"Status\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + startingId++ + ", " + learnerId + ", "
                                      + unit.Id + ", '" + DateTime.Now + "', " + 0 +");");
                    sqlBuilder.AppendLine().AppendLine();
                }
                foreach (var kc in kcs)
                {
                    sqlBuilder.Append(
                        "INSERT INTO public.\"KcMasteries\"(\"Id\", \"Mastery\", \"KnowledgeComponentId\", \"LearnerId\", \"IsPassed\", \"IsSatisfied\", \"HasActiveSession\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + startingId++ + ", 0.00, " + kc.Id + ", "
                                      + learnerId + ", false, false, false);");
                    sqlBuilder.AppendLine().AppendLine();
                }
            }

            return sqlBuilder.ToString();
        }
    }
}