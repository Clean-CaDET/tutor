using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.DomainExcelModel;

namespace Tutor.Infrastructure.Database.DataImport
{
    internal static class LearnerSqlExporter
    {
        internal static string BuildSql(List<LearnerColumns> learners, List<KCColumns> kcs, List<UnitColumns> units)
        {
            return BuildLearnerSql(learners) + BuildMasterySql(learners, kcs, units);
        }

        private static string BuildLearnerSql(List<LearnerColumns> learners)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine().AppendLine();
            foreach (var learner in learners)
            {
                sqlBuilder.Append("INSERT INTO public.\"Learners\"(\"Id\", \"StudentIndex\", \"Name\", \"Surname\", \"Password\", \"Salt\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + learner.Id + ", '" + learner.StudentIndex + "', '"
                                    + learner.Name + "', '" + learner.Surname + "', '"
                                  + learner.Password + "', '" + learner.Salt + "');");
                sqlBuilder.AppendLine().AppendLine();
            }

            return sqlBuilder.ToString();
        }

        private static string BuildMasterySql(List<LearnerColumns> learners, List<KCColumns> kcs, List<UnitColumns> units)
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